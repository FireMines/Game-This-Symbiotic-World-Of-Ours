using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target; //enemies target -> probably player
    [SerializeField] private float targetRange; //how close must player get to be detected
    [SerializeField] private float speed; //how fast does the enemy move towards the player
    [SerializeField] private int damage; //how much damage does the enemy do
    [SerializeField] private PlayerHealth playerHealth; //Player Health script with the takeDamage function
    [SerializeField] private SpriteRenderer _enemySprite; 
    private const int distance = 500; //how far does the enemy walk when player is not in range
    private float XPosition; //current position of the enemy
    private int movementIndex = 1; //measures the distance that the enemy has walked so far
    private bool counterUp = true; // position = position +1 if true, -1 if false   

    private void Start(){
        //get the enemies starting position as the starting position the enemy moves from
        XPosition = transform.position.x;
    }
    private void Update(){
        enemyMovement();
        //add flip
    }

    private void enemyMovement(){
        //player detection, meaning as soon as ememy "sees" player (player is within range distance) it walks towards him
        float playerDistance = Vector3.Distance(target.position, transform.position);

        if(playerDistance <= targetRange){
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);      
        }else{

        //move the enemy a set distance from the starting point and then back
        float newXPosition = 0f;

        if(counterUp){
            //counterUp is true when the enemy is moving right(position=position+0.01), and false if the enemy is moving left(position=position-0.01)
            XPosition = XPosition+0.01f;
            movementIndex++;
        }else{
            XPosition = XPosition-0.01f;
            movementIndex--;
        }

        transform.position = new Vector3(XPosition, transform.position.y, transform.position.z); //move player
        
        switch(movementIndex){
            //set counter up true if the enemy is at its starting position and has to turn around
            //set counter up false if the enemy is at its end position(=starting position+distance) and has to turn around
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
            playerHealth.takeDamage(damage); //enemy damages player when the player is hit
            Debug.Log("Damage taken");
            //add enemy "bounces" back after hit
        }
    }

}
