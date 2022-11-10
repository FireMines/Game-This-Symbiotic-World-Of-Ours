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

    void Damage()
    {
        _healthController.playerHealth = _healthController.playerHealth - damage;
        _healthController.UpdateHealth();
        gameObject.SetActive(false);
    }
}
