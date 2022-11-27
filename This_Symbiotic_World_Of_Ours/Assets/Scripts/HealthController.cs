using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public int      health;                 // Health of the mob
    public bool     displayHP = false;      // Show health if mob is player character
    private Color   colour;

    public string SceneToLoadOnDeath;


    private void Start()
    {

    }


    IEnumerator DelayedDeath()
    {
        Destroy(gameObject);
        Die();
        Time.timeScale = 0f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
    }


    /// <summary>
    /// When health goes to 0, either destroy enemy or respawn if player
    /// </summary>
    public void Die()
    {
        //StartCoroutine("DelayedDeath");
        Destroy(gameObject);



        if (gameObject.CompareTag("Player"))
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
            SceneManager.UnloadScene(SceneManager.GetSceneAt(i));
            //SceneManager.GetActiveScene();
            //SceneManager.LoadScene(i);
            // Unloads all scenes passed through
            //Application.LoadLevel(Application.loadedLevel);
        }

        // Load scene
        SceneManager.LoadScene(SceneToLoadOnDeath, LoadSceneMode.Additive);

        Debug.Log("Papa is that you?");
    }


    /// <summary>
    /// Deals damage to the unit
    /// </summary>
    /// <param name="damage"></param>
    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Die();//StartCoroutine("DelayedDeath");

        //UpdateHealth();
        //gameObject.SetActive(false);
    }
}
