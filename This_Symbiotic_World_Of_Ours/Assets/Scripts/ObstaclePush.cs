using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    
    private float playerSpeed = 40f;    //player speed
    private float distanceToPlayer; //distance of the middle of the game object to the player when pushing
    private float pushObjectWidth;  //width of the push object
    private float pushObjectHeight; //height of the push object
    GameObject pushObject;  //object that should be pushed
    GameObject textObject;  //text next to the object  
    Renderer textRenderer;  //renderer for the text object
    [SerializeField] PlayerMovement playerMovement; //player movement script
    [SerializeField] private Transform m_pushCheck_c1;  //first corner of the collision check
    [SerializeField] private Transform m_pushCheck_c2;  //second corner of the collision check
    
    void Start(){
        //initalize the player speed to that set in the player movement script
        playerSpeed = playerMovement.runSpeed;
    }
    

    void Update(){
        Collider2D[] colliders = Physics2D.OverlapAreaAll(m_pushCheck_c1.position, m_pushCheck_c2.position);

		for (int i = 0; i < colliders.Length; i++)
		{
            if(pushObject==null)
            {   //get object from the collision
                pushObject = colliders[i].gameObject;
            }
            else if(pushObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" )
            {   //delete push object if it's not pushable                
                pushObject=null;
            }
		}
            if(pushObject != null && pushObject.tag == "Pushable" )
            {
                moveObject();
            }else if(pushObject != null && pushObject.tag == "PushableTree" )
            {
                pushOverObject();
            }else {
                playerMovement.setIsPulling(false);
                if(textRenderer!=null){
                    textRenderer.enabled = false;
                    textObject = null;
                    textRenderer = null;
                
                }
                pushObject = null;
            }
    }

    /// <summary>
    /// pushes the object over if the e key is pressed
    /// </summary>
    private void pushOverObject(){
        textObject = pushObject.transform.GetChild (0).gameObject;
        textRenderer = textObject.GetComponent<Renderer>();
        textRenderer.enabled = true;
        textObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, textObject.transform.parent.rotation.z * -1.0f);

        if(Input.GetKey(KeyCode.E)){

            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            //push element over
            
            pushObject.transform.Rotate(0.0f, 0.0f, -1.0f);
            print(pushObject.transform.rotation);

            //if(pushObject.transform.rotation == new Quaternion(0.00000f, 0.00000f, -0.64683f, 0.76263f)){
            if (pushObject.transform.rotation.z <= -0.64683f && pushObject.transform.rotation.w <= 0.76263f) { 
                pushObject.gameObject.tag = "Untagged";
                textRenderer.enabled = false;
            }
            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            
        }else{
            textRenderer.enabled = true;
            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            playerMovement.setSpeed(playerSpeed);
            playerMovement.setIsPulling(false);
            pushObject = null;
        }
    }

    /// <summary>
    /// pushes/pulls an object if the e key is pressed
    /// </summary>
    private void moveObject()
    {
        pushObjectWidth = pushObject.GetComponent<Renderer>().bounds.size.x;
        distanceToPlayer = pushObjectWidth/2f;
        pushObjectHeight = pushObject.GetComponent<Renderer>().bounds.size.y;

        textObject = pushObject.transform.GetChild (0).gameObject; 
        textRenderer = textObject.GetComponent<Renderer>();
        textRenderer.enabled = true;
        textObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, textObject.transform.parent.rotation.z * -1.0f);
        Vector2 textPos = new Vector2(gameObject.transform.position.x, pushObject.transform.position.y+(pushObjectHeight/2 +0.5f));
        textObject.transform.position = textPos;

        if(Input.GetKey(KeyCode.E)){

            textRenderer.enabled = false;

            playerMovement.setIsPulling(true);
            float newSpeed = playerSpeed-30;
            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            
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
                pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                textRenderer.enabled = true;

                playerMovement.setSpeed(playerSpeed);
                playerMovement.setIsPulling(false);
                pushObject = null;
            }
    }

}
