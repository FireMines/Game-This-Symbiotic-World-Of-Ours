using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;

    [SerializeField] private HealthController _healthController;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Damage();
            Debug.Log("DAMAGE DONE TO PLAYER");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //_healthController = _healthController.gameObject.GetComponent<HealthController>();
        //playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (collision.gameObject.tag == "Player")
        {
            //_healthController.takeDamage(damage); //enemy damages player when the player is hit
            Debug.Log("Damage " + damage + " taken" + " Health left: " + _healthController);

            //enemy "bounces" back when it hits the player
            //float bounceForce = 200f; //amount of force to apply
            //_enemyRB.AddForce(collision.contacts[0].normal * bounceForce);
            //isBouncing = true;
            //Invoke("StopBouncing", 0.2f);
        }
    }


    void Damage()
    {
        _healthController.health = _healthController.health - damage;
        _healthController.UpdateHealth();
        gameObject.SetActive(false);
    }
}
