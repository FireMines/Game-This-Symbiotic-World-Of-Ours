using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int health;

    void Start()
    {
        //player health is set to max when the game starts
        health=maxHealth;   
    }

    public void takeDamage(int damage){
        //damage is deducted from player's current health
        health-=damage;
        if(health<=0){
            //player dies at health=0
            Debug.Log("Player is dead"); 
            //now what?
        }
    }
}
