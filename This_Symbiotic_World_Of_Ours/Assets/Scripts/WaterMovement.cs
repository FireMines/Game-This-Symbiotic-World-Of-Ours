using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class WaterMovement : MonoBehaviour
{

    public GameObject obstacle = null;
    private float obstacleStartPosx;
   
    public float distanceToActivate;

    public float _NewY;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //finds the startign position of the obstacle
        obstacleStartPosx = obstacle.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        //check if object is destroyed
        if (!obstacle) WaterDrain();

        //check if object is moved
        else if (Mathf.Abs(obstacle.transform.position.x - obstacleStartPosx) >= distanceToActivate) WaterRise(); 
    }

    /// <summary>
    /// Rises the water in Water Level
    /// </summary>
    private void WaterRise()
    {
        if (transform.position.y < _NewY)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, 0);
        }
    }

    /// <summary>
    /// Drains the water in Earth Level
    /// </summary>
    private void WaterDrain()
    {
        if (transform.position.y > _NewY) 
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y+speed, 0);
        }

    }

}
