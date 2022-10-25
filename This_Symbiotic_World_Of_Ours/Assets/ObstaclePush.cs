using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;
    

    void Update(){
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDist);
        if(grabCheck.collider != null && grabCheck.collider.gameObject.GetComponent<Rigidbody2D>()!= null && grabCheck.collider.tag != "Pushable" ){
            grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        if(grabCheck.collider != null && grabCheck.collider.tag == "Pushable" ){
            if(Input.GetKey(KeyCode.G)){
                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=0.00001F;
            }else{
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().mass=1F;//grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }
}
