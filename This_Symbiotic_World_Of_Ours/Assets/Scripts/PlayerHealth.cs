using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 20;
    [SerializeField] private int health;
    [SerializeField] private Image[] LifeCells;


    void Start()
    {
        //player health is set to max when the game starts
        health=maxHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Father");

            Die();
        }

        for (int i = 0; i < LifeCells.Length; i++)
        {
            if (i < health)
            {
                LifeCells[i].color = Color.green;
            }
            else
            {
                LifeCells[i].color = Color.black;
            }
        }
    }

    public void Die()
    {
        //Application.LoadLevel(Application.loadedLevel);
        // Unload all other scenes that arent DoNotUnload
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;

            SceneManager.GetActiveScene();
            //SceneManager.LoadScene(i);
            // Unloads all scenes passed through
            Application.LoadLevel(Application.loadedLevel);
        }

        // Load scene
        //SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
    }

    public void takeDamage(int damage){
        //damage is deducted from player's current health
        health-=damage;
        if(health<=0){
            //player dies at health=0
            Debug.Log("Player is dead");
            Die();
            //now what?
        }
    }

}
