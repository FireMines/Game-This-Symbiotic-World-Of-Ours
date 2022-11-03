using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: -comment all my code!!
//      -flip enemy when it turns around  

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float targetRange;
    public float speed;
    [SerializeField] private int damage;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private SpriteRenderer _enemySprite;
    private const int distance = 500;
    private float XPosition;
    private int movementIndex = 1;
    private bool counterUp = true; // position = position +1 if true, -1 if false   

    private void Start(){
        //get the enemies starting position as the "main" position the enemy moves from
        XPosition = transform.position.x;
    }
    private void Update(){
        enemyMovement();
    }

    private void enemyMovement(){
        //move the enemy a set distance from the starting point and then back(e.g. +/-5)
        //player detection, meaning as soon as ememy "sees" player it walks towards him
        float playerDistance = Vector3.Distance(target.position, transform.position);
        if(playerDistance <= targetRange){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);      
        }else{

        float newXPosition = 0f;
        if(counterUp){
            XPosition = XPosition+0.01f;
            movementIndex++;
        }else{
            XPosition = XPosition-0.01f;
            movementIndex--;
        }
        transform.position = new Vector3(XPosition, transform.position.y, transform.position.z);
        
        switch(movementIndex){
            case 0:
                counterUp=true;
                break;
            case distance:
                counterUp=false;
                break;
        }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){
            playerHealth.takeDamage(damage);
            Debug.Log("Damage taken");
        }
    }

}
