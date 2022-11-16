using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int      health;                 // Health of the mob
    public bool     displayHP = false;      // Show health if mob is player character

    // All Life Cells
    [SerializeField] private List<Image> LifeCells = new List<Image>();

    private void Start()
    {
       UpdateHealth();
    }

    public void UpdateHealth()
    {
        if(health <= 0)
        {

            //Die();
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


    public void createHealthImageBasedOnHP ()
    {

    }

    public void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
            return;
        }

        Destroy(gameObject);
    }
}
