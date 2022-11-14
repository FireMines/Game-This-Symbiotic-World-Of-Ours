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

    void OnCollisionExit2D(Collision2D col){
        pushObject = null;
    }

    void Update(){
        
        if(pushObject != null && pushObject.tag!="Enemy"){//check that collided game object is not an enemy!! player should not be able to pull and push them
            if(pushObject != null && pushObject.gameObject.GetComponent<Rigidbody2D>() != null && pushObject.tag != "Pushable" ){
                //freeze it's position if it's not pushable
                pushObject.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            if(pushObject != null && pushObject.tag == "Pushable" ){
                if(Input.GetKey(KeyCode.E)){
                    //if e is pressed, push or pull the object
                    pushObject.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                    //add dragging here, drag with AddForce maybe?
                    //get direction by which key is pressed, then -> object.AddForce(+/- speed of player, 0f) -> no, doesn't look good
                    //make it follow the player instead
                    // not quite: grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().transform.position = Vector2.MoveTowards(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().transform.position, gameObject.transform.position, playerSpeed/10);
                    
                }else{
                    pushObject.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

                    }
            }
        }
    }
}
