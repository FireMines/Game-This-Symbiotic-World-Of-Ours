using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterMovement : MonoBehaviour
{

    public GameObject obstacle;
    private float obstacleStartPosx;
   
    public float distanceToActivate;

    public float _NewY;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        obstacleStartPosx = obstacle.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!obstacle) WaterDrain();

        if (Mathf.Abs(obstacle.transform.position.x - obstacleStartPosx) >= distanceToActivate) WaterRise();
        
    }

    private void WaterRise()
    {
        if (transform.position.y < _NewY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
        }
    }

    private void WaterDrain()
    {
        if (transform.position.y > _NewY) { 
        transform.position = new Vector3(transform.position.x, transform.position.y+speed, 0);
            }

    }

}
