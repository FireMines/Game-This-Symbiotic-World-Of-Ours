using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] private Transform target;                //enemies target -> probably player
    [SerializeField] private float          targetRange;        //how close must player get to be detected
    [SerializeField] private float          speed;              //how fast does the enemy move towards the player
    [SerializeField] private int            damage;             //how much damage does the enemy do
    [SerializeField] private SpriteRenderer _enemySprite; 
    [SerializeField] private Rigidbody2D    _enemyRB; 
    private const int                       distance = 500;     //how far does the enemy walk when player is not in range
    private float                           XPosition;          //current position of the enemy
    private int                             movementIndex = 1;  //measures the distance that the enemy has walked so far
    private bool                            counterUp = true;   // position = position +1 if true, -1 if false
    
	private bool m_FacingRight = true;              // For determining which way the enemy is currently facing.

    private bool canDamage = true;
    private float damageCooldown = 1f;

    private Transform target;


    private void Start(){
        //get the enemies starting position as the starting position the enemy moves from
        XPosition = transform.position.x;
        target=GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate(){
        enemyMovement();
    }

    /// <summary>
    /// defines the enemies movement making it move left and right when no player is in range and making it move towards the player if he is in range
    /// </summary>
    private void enemyMovement(){

        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        Vector3 playerPos = playerGameObject.transform.position;
        float playerDistance = Vector2.Distance(playerPos, transform.position);
  
        if(playerDistance <= targetRange){
            //if player pos>enemy pos and enemy is facing left -> flip
            if((playerPos.x < XPosition && m_FacingRight) || (playerPos.x > transform.position.x  &&! m_FacingRight)){
                Flip();
            }
            //if player pos<enemy pos and enemy is facing right -> flip
            float move = speed/2000f;
            transform.position = Vector2.MoveTowards(transform.position, playerPos, move);
            XPosition = transform.position.x;
        }else{
            //move the enemy a set distance from the starting point and then back
            switch (counterUp){
                case true:
                    //counterUp is true when the enemy is moving right and false if the enemy is moving left
                    XPosition = XPosition + 0.01f;
                    movementIndex++;
                break;
                case false:
                    XPosition = XPosition - 0.01f;
                    movementIndex--;
                break;
            }

            transform.position = new Vector3(XPosition, transform.position.y, transform.position.z);
            
            switch(movementIndex){
                //set counter up true if the enemy is at its starting position and has to turn around
                //set counter up false if the enemy is at its end position and has to turn around
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

    /// <summary>
    /// flips the enemy sprite
    /// </summary>
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
        if (collision.gameObject.tag != "Player") return;
        
        if(canDamage){
            StartCoroutine(Damage(collision));    
        }    
        
    }

    /// <summary>
    /// pushes the object over if the e key is pressed
    /// </summary>
    /// <param name="collision">the player object that the enemy collided with</param>
    private IEnumerator Damage(Collision2D collision)
    {
        canDamage = false;
        HealthController playerHealthController = collision.gameObject.GetComponent<HealthController>();

        playerHealthController.takeDamage(damage);
        //enemy "bounces" back when it hits the player
        float bounceForce = 225f; //amount of force to apply to the bounce
        _enemyRB.AddForce(collision.contacts[0].normal * bounceForce);
        Invoke("StopBouncing", 0.2f);
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
