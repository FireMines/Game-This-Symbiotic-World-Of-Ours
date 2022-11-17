using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField] private float objectMass;
    [SerializeField] private float playerSpeed;
    GameObject pushObject;
    
    //if i get collision and its object in OnCollision, no need for grabCheck?
    void OnCollisionEnter2D(Collision2D col){
        //get collision object
        if(pushObject==null){
            pushObject = col.gameObject;
        }
        
        if(pushObject != null && pushObject.tag!="Enemy"){//check that collided game object is not an enemy!! player should not be able to pull and push them
            if(pushObject != null && pushObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" ){
                //freeze it's position if it's not pushable
                pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                pushObject=null;
            }
        }else{
            pushObject=null;
        }
    }

    void Update(){
            if(pushObject != null && pushObject.tag == "Pushable" ){
                if(Input.GetKey(KeyCode.E)){
                    pushObject.GetComponent<Rigidbody2D>().mass=0f;
                    //if e is pressed, push or pull the object
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    //for it to work properly, now: if player is walking towards rock -> push
                    //if player is walking away from rock -> pull
                    if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
                        //if player pos > rock pos:
                        print("right");
                        if(gameObject.transform.position.x>pushObject.transform.position.x){
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, gameObject.transform.position , playerSpeed / 350f);
                        }
                        //else nothing, rock gets pushed normally
                    }
                    if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
                        print("left");
                        //if player pos < rock pos:
                        if(gameObject.transform.position.x<pushObject.transform.position.x){
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, gameObject.transform.position , playerSpeed / 350f);
                        }
                    }
                    
                }else{
                    //if you want object to stop when e is not pressed anymore: else just comment it out
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    pushObject = null;
                }
            }else{pushObject = null;}
    }
}
