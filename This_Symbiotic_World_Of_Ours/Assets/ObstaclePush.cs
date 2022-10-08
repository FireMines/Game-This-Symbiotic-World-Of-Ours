using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    private float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rigidbody = collision.rigidbody;

        if(rigidbody != null && rigidbody.tag != "Pushable" && rigidbody.tag !="Player") 
        {   
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;        
        }
    }
}
