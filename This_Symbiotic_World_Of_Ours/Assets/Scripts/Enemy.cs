using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;                //enemies target -> probably player
    [SerializeField] private float          targetRange;        //how close must player get to be detected
    [SerializeField] private float          speed;              //how fast does the enemy move towards the player
    [SerializeField] private int            damage;             //how much damage does the enemy do
    
    private PlayerHealth                    playerHealth;       //Player Health script with the takeDamage function
    [SerializeField] float                  enemyHealth;

    [SerializeField] private SpriteRenderer _enemySprite; 
    [SerializeField] private Rigidbody2D    _enemyRB; 
    private const int                       distance = 500;     //how far does the enemy walk when player is not in range
    private float                           XPosition;          //current position of the enemy
    private int                             movementIndex = 1;  //measures the distance that the enemy has walked so far
    private bool                            counterUp = true;   // position = position +1 if true, -1 if false
    
	private bool m_FacingRight = true;              // For determining which way the enemy is currently facing.

    private bool isBouncing = false;

    private Transform target;

    private void Start(){
        //get the enemies starting position as the starting position the enemy moves from
        XPosition = transform.position.x;
        target=GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update(){
        enemyMovement();
    }

    private void enemyMovement(){

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = playerGameObject.transform.position;
        //player detection, meaning as soon as ememy "sees" player (player is within range distance) it walks towards him
        float playerDistance = Vector2.Distance(playerPos, transform.position);
  
        if(playerDistance <= targetRange){
            //if player pos>enemy pos and enemy is facing left -> flip
            if(playerPos.x < XPosition && m_FacingRight){
                Flip();
            } else if(playerPos.x > transform.position.x  &&! m_FacingRight){
                Flip();
            }
            //if player pos<enemy pos and enemy is facing right -> flip
            float move = speed * Time.fixedDeltaTime;///4000f;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, move / 80f);      //* Time.deltaTime makes the enemy not move
            XPosition = transform.position.x;
        }else{
            //move the enemy a set distance from the starting point and then back
            if(counterUp){
                //counterUp is true when the enemy is moving right(position=position+0.01), and false if the enemy is moving left(position=position-0.01)
                XPosition = XPosition + 0.01f;
                movementIndex++;
            }else{
                XPosition = XPosition - 0.01f;
                movementIndex--;
            }

            transform.position = new Vector3(XPosition, transform.position.y, transform.position.z); //move player
            //Vector3 playerPos = playerGameObject.transform.position;
            
            switch(movementIndex){
                //set counter up true if the enemy is at its starting position and has to turn around
                //set counter up false if the enemy is at its end position(=starting position+distance) and has to turn around
                case 0:
                    Flip();
                    counterUp=true;
                    break;
                case distance:
                    Flip();
                    counterUp=false;
                    break;
            }
        }
    }

    private void Flip()
	{
		// Switch the way the enemy is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the enemy's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    private void OnCollisionEnter2D(Collision2D collision){
        playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if(collision.gameObject.tag=="Player"){
            playerHealth.takeDamage(damage); //enemy damages player when the player is hit
            Debug.Log("Damage " + damage + " taken" + " Health left: " + playerHealth);

            //enemy "bounces" back when it hits the player
            float bounceForce = 200f; //amount of force to apply
            _enemyRB.AddForce(collision.contacts[0].normal * bounceForce);
            isBouncing = true;
            Invoke("StopBouncing", 0.2f);
        }
    }

    private void StopBouncing()
    {
        isBouncing = false;
    }

    public void takeDamage(int damage)
    {
        //damage is deducted from enemy's current health
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            //enemy dies and the game object gets destroyed if its health=0
            Debug.Log("Mother");
            Destroy(gameObject);
        }
    }

}
