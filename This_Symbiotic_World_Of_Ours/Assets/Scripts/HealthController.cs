using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int      health;                 // Health of the mob
    public bool     displayHP = false;      // Show health if mob is player character
    private Color   colour;

    public Image LifeCell;
    public Image deathScreen;

    // All Life Cells
    [SerializeField] private List<Image> LifeCells = new List<Image>();

    private void Start()
    {
        //createHealthImageBasedOnHP();
        //UpdateHealthbar();
    }


    /// <summary>
    /// Updates how much health is left on the player health bar
    /// </summary>
    public void UpdateHealthbar()
    {
        if(health <= 0)
        {
            //Vector4 screenColor;
            //screenColor.Set(0, 0, 0, 255);
            //screenColor.
            // Attempts to fade screen to black when dead
            deathScreen.color = new Color(0f, 0f, 0f, Mathf.PingPong(Time.time, 1));
        }

        if (!displayHP) return;

        for (int i = 0; i < LifeCells.Count; i++)
        {
            if (i < health)
            {
                LifeCells[i].enabled = true;
                LifeCells[i].color = Color.green;
            } else
            {
                LifeCells[i].enabled = false;
                LifeCells[i].color = Color.black;
            }
        }
    }


    /// <summary>
    /// Creates the amount of Lifecells the player have on screen display
    /// </summary>
    public void createHealthImageBasedOnHP ()
    {
        Vector2 lifecellPos;
        lifecellPos.x = -150;
        lifecellPos.y = 50;
        for(int i = 0; i < health; i++)
        {
            lifecellPos.x += 100;
            LifeCell.gameObject.transform.position = lifecellPos;
            LifeCells.Add(LifeCell);

        }
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
