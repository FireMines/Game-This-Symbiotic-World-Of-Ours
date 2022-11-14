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
    }

    void Update(){
        
        if(pushObject != null && pushObject.tag!="Enemy"){//check that collided game object is not an enemy!! player should not be able to pull and push them
            if(pushObject != null && pushObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" ){
                //freeze it's position if it's not pushable
                pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            if(pushObject != null && pushObject.tag == "Pushable" ){
                if(Input.GetKey(KeyCode.E)){
                    //if e is pressed, push or pull the object
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    //if key right is pressed -> move towards position + speed
                    //if key left is pressed -> move towards position - speed
                    if(Input.GetKey("right") || Input.GetKey(KeyCode.D)){
                        print("right");
                        Vector2 newPos = new Vector2(pushObject.transform.position.x + 2f, pushObject.transform.position.y);
                        pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , playerSpeed / 100f);
                    }
                    if(Input.GetKey("left") || Input.GetKey(KeyCode.A)){
                        print("left");
                        Vector2 newPos = new Vector2(pushObject.transform.position.x - 2f, pushObject.transform.position.y);
                        pushObject.transform.position = Vector2.MoveTowards(pushObject.transform.position, newPos , playerSpeed / 100f);
                    }
                    
                }else{
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    pushObject = null;
                }
            }else{pushObject = null;}
        }else{pushObject = null;}
    }
}
