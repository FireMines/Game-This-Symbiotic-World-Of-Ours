using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int      health;                 // Health of the mob
    public bool     displayHP = false;      // Show health if mob is player character
    private Color   colour;

    private void Start()
    {

    }


    /// <summary>
    /// When health goes to 0, either destroy enemy or respawn if player
    /// </summary>
    public void Die()
    {
        /*if (gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
            return;
        }
        // Application.LoadLevel(Application.loadedLevel);
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
*/

        Destroy(gameObject);
    }


    /// <summary>
    /// Deals damage to the unit
    /// </summary>
    /// <param name="damage"></param>
    public void takeDamage(int damage)
    {
        Debug.Log(damage);
        Debug.Log(health);
        health -= damage;

        if (health <= 0) Die();

        //UpdateHealth();
        //gameObject.SetActive(false);
    }
}
