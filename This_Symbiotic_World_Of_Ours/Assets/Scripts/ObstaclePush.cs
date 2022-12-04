using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    
    private float playerSpeed = 40f;
    GameObject pushObject;
    [SerializeField] PlayerMovement playerMovement;

    void Start(){
        //get the player speed from the player movement script
        playerSpeed = playerMovement.runSpeed;
    }
    
    //if i get collision and its object in OnCollision, no need for grabCheck?
    void OnTriggerEnter2D(Collider2D col){

        Debug.Log("Collision detected");
        if(pushObject==null){
            //get collision object
            pushObject = col.gameObject;
        }
        else if(pushObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" ){
            if(pushObject.tag!="Enemy"){//check that collided game object is not an enemy!! player should not be able to pull and push them
            
                //freeze it's position if it's not pushable
                pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            pushObject=null;
        }
    }

    void Update(){
        //todo: not jump while pulling
            if(pushObject != null && pushObject.tag == "Pushable" ){

                if(Input.GetKey(KeyCode.E)){
                    Debug.Log("key detected");
                    playerMovement.setIsPulling(true);
                    //if e is pressed, push or pull the object
                    float newSpeed = playerSpeed-35;
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    //if player is walking towards rock -> push
                    //if player is walking away from rock -> pull
                    if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
                        //if player pos > rock pos:
                        if(gameObject.transform.position.x>pushObject.transform.position.x){
                            playerMovement.setSpeed(newSpeed); //slow player down while moving object
                            Vector2 newPos = new Vector2(gameObject.transform.position.x-0.5f, gameObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , newSpeed / 355f);
                        }
                    }
                    if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
                        //if player pos < rock pos:
                        if(gameObject.transform.position.x<pushObject.transform.position.x){
                            playerMovement.setSpeed(newSpeed);//slow player down while moving object
                            Vector2 newPos = new Vector2(gameObject.transform.position.x+0.5f, gameObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , newSpeed / 355f);
                        }
                    }
                    
                }else{
                    //if you want object to stop when e is not pressed anymore: else just comment it out
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    playerMovement.setSpeed(playerSpeed);
                    playerMovement.setIsPulling(false);
                    pushObject = null;
                }
            }else{
                pushObject = null;
                }
    }
}
