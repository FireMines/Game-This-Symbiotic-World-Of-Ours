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
        pushObject = col.gameObject;
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
                    
                    pushObject.GetComponent<Rigidbody2D>().transform.position = Vector2.MoveTowards(pushObject.GetComponent<Rigidbody2D>().transform.position, gameObject.transform.position, playerSpeed/10);

                }else{
                    pushObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                    pushObject = null;
                }
            }
        }
    }
}
