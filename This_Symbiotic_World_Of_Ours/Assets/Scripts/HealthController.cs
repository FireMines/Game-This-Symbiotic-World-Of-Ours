using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] LifeCells;

    private void Start()
    {
       UpdateHealth();
    }

    public void UpdateHealth()
    {
        if(playerHealth <= 0)
        {
            Debug.Log("Ori iskibena");

            Die();
        }

        for (int i = 0; i < LifeCells.Length; i++)
        {
            if (i < playerHealth)
            {
                LifeCells[i].color = Color.green;
            } else
            {
                LifeCells[i].color = Color.black;
            }
        }
    }

    public void Die()
    {
        Application.LoadLevel(Application.loadedLevel);

    }
}
