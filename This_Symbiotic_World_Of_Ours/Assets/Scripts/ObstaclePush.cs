using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    
    private float playerSpeed = 40f; //player speed
    private float distanceToPlayer; //distance of the middle of the game object to the player when pushing
    private float colliderWidth; //width of the collided object
    GameObject pushObject; //object that should be pushed
    GameObject textObject;
    Renderer textRenderer;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] private Transform m_pushCheck_c1;
    [SerializeField] private Transform m_pushCheck_c2;			

    void Start(){
        //get the player speed from the player movement script
        playerSpeed = playerMovement.runSpeed;
    }
    

    void Update(){
        //todo: not jump while pulling
        Collider2D[] colliders = Physics2D.OverlapAreaAll(m_pushCheck_c1.position, m_pushCheck_c2.position);

		for (int i = 0; i < colliders.Length; i++)
		{
            if(pushObject==null){
                //get collision object
                pushObject = colliders[i].gameObject;
                //set the distanceToPlayer to half of the game objects width
            }
            else if(pushObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" ){
                pushObject=null;
            }
		}
            if(pushObject != null && pushObject.tag == "Pushable" ){

                colliderWidth = pushObject.GetComponent<Renderer>().bounds.size.x;
                distanceToPlayer = colliderWidth/2f;

                textObject = pushObject.transform.GetChild (0).gameObject;
                 
                textRenderer = textObject.GetComponent<Renderer>();
                textRenderer.enabled = true;

                textObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, textObject.transform.parent.rotation.z * -1.0f);
                //set position of child to position of parent + 1f
                Vector2 childPos = new Vector2(gameObject.transform.position.x, pushObject.transform.position.y+colliderWidth/2);
                textObject.transform.position = childPos;

                if(Input.GetKey(KeyCode.E)){

                    textRenderer.enabled = false;

                    

                    playerMovement.setIsPulling(true);
                    //if e is pressed, push or pull the object
                    float newSpeed = playerSpeed-30;
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    
                    //if player is walking towards rock -> push
                    //if player is walking away from rock -> pull
                    if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
                        //if player pos > rock pos:
                        if(gameObject.transform.position.x>pushObject.transform.position.x){
                            playerMovement.setSpeed(newSpeed); //slow player down while moving object
                            Vector2 newPos = new Vector2(gameObject.transform.position.x-distanceToPlayer, pushObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , newSpeed/10f);
                        }
                    }
                    if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
                        //if player pos < rock pos:
                        if(gameObject.transform.position.x<pushObject.transform.position.x){
                            playerMovement.setSpeed(newSpeed);//slow player down while moving object
                            Vector2 newPos = new Vector2(gameObject.transform.position.x+distanceToPlayer, pushObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , newSpeed/10f);
                        }
                    }

                    
                }else{
                    //if you want object to stop when e is not pressed anymore: else just comment it out
                    textRenderer.enabled = true;

                    playerMovement.setSpeed(playerSpeed);
                    playerMovement.setIsPulling(false);
                    pushObject = null;
                }
            }else{

                if(textRenderer!=null){
                    textRenderer.enabled = false;
                    textObject = null;
                    textRenderer = null;
                
                }
                pushObject = null;
                }
    }
}
