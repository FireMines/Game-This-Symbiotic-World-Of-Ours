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
        //todo: mass slow player down while pulling, get player speed from player, not jump while pulling
            if(pushObject != null && pushObject.tag == "Pushable" ){
                if(Input.GetKey(KeyCode.E)){
                    //pushObject.GetComponent<Rigidbody2D>().mass=0f;
                    //if e is pressed, push or pull the object
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                    //for it to work properly, now: if player is walking towards rock -> push
                    //if player is walking away from rock -> pull
                    if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
                        //if player pos > rock pos:
                        print("right");
                        if(gameObject.transform.position.x>pushObject.transform.position.x){
                            Vector2 newPos = new Vector2(gameObject.transform.position.x-1.5f, gameObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , playerSpeed / 350f);
                        }
                        //else nothing, rock gets pushed normally
                    }
                    if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
                        print("left");
                        //if player pos < rock pos:
                        if(gameObject.transform.position.x<pushObject.transform.position.x){
                            Vector2 newPos = new Vector2(gameObject.transform.position.x+1.5f, gameObject.transform.position.y);
                            pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , playerSpeed / 350f);
                        }
                    }
                    
                }else{
                    //if you want object to stop when e is not pressed anymore: else just comment it out
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                    pushObject = null;
                }
            }else{
                pushObject = null;
                }
    }
}
