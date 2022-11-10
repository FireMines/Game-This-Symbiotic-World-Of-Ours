using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int health;

    void Start()
    {
        //enemy health is set to max when the game starts
        health=maxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Blobb");

        }
    }

        public void takeDamage(int damage){
        //damage is deducted from enemy's current health
        health-=damage;
        if(health<=0){
            //enemy dies and the game object gets destroyed if its health=0
            Debug.Log("Enemy is dead");
           Destroy(gameObject);
        }
    }
}
