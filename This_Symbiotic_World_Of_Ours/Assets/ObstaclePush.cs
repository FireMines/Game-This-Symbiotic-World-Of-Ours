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
        if(grabCheck.collider != null && grabCheck.collider.tag!="Enemy"){//collided game object is not an enemy
            if(grabCheck.collider != null && grabCheck.collider.gameObject.GetComponent<Rigidbody2D>()!= null && grabCheck.collider.tag != "Pushable" ){ 4
                //freeze it's position if it's not pushable
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            }
            if(grabCheck.collider != null && grabCheck.collider.tag == "Pushable" ){
                if(Input.GetKey(KeyCode.E)){
                    //if e is pressed, grab the object
                    grabCheck.collider.gameObject.transform.parent = boxHolder;
                    grabCheck.collider.gameObject.transform.position = boxHolder.position;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=0.00001F;
                }else{
                    //if e is released, set object down and set mass back to default
                    grabCheck.collider.gameObject.transform.parent = null;
                    grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=objectMass;
                    }
            }
        }
    }
}
