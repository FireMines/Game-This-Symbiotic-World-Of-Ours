using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField] private Transform grabDetect; //game object to detect if something is close enough to grab
    [SerializeField] private Transform boxHolder; //game object to determine where grabbed object is held
    [SerializeField] private float rayDistance; 
    [SerializeField] private float objectMass; 
    

    void Update(){
        
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);
        Rigidbody2D objectRB = grabCheck.collider.gameObject.GetComponent<Rigidbody2D>();
        if(grabCheck.collider != null && grabCheck.collider.tag!="Enemy"){//collided game object is not an enemy
            if(grabCheck.collider != null && objectRB != null && grabCheck.collider.tag != "Pushable" ){
                //freeze it's position if it's not pushable
                objectRB.constraints = RigidbodyConstraints2D.FreezePosition;
            }
            if(grabCheck.collider != null && grabCheck.collider.tag == "Pushable" ){
                 objectRB.constraints = RigidbodyConstraints2D.None;
                if(Input.GetKey(KeyCode.E)){
                    //if e is pressed, grab the object
                    //literally none of this will work with the way the scenes are set up now -> redo all of it
                    /*grabCheck.collider.gameObject.transform.parent = boxHolder;
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=0.00001F;*/
                }else{
                    //if e is released, set object down and set mass back to default
                    /*grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=objectMass;*/
                    }
            }
        }
    }
}
