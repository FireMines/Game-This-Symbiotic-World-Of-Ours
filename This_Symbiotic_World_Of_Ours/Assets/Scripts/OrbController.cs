using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OrbController : MonoBehaviour
{
    public enum Element{
    Water,
    Earth
    }

    public enum Powerup
    {
        DoubleJump,
        RangedAttack,
        ChargedRangedAttack,
        Glide,
        CharacterGlowing,
        Dash
    }

    public Element OrbElement;

    public Powerup powerup;

    private CharacterController2D controller;

    private PlayerMovement movement;

    SpriteRenderer sprite;

    ParticleSystem orbLight;



    void Start() {
        GameObject[] playerTaggedObjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerTaggedObjects.Length <= 0) Debug.Log("Error fordi det ikke finnes en player??? dette skal egt ikke skje");
        GameObject player = playerTaggedObjects[0];
        controller = player.GetComponent<CharacterController2D>();
        if (controller == null) Debug.Log("Error fordi det ikke finnes en playercontroller??? dette skal egt ikke skje");

        sprite = GetComponentInChildren<SpriteRenderer>();

        orbLight = GetComponentInChildren<ParticleSystem>();

        switch (OrbElement)
        {
            case Element.Water:
                sprite.color = new Color(0f, 0.69f, 1f);
                orbLight.startColor = new Color(0f,0.69f,1f);
                break;

            case Element.Earth:
                sprite.color = new Color(1f, 0.5f, 0f);
                orbLight.startColor = new Color(1f, 0.5f, 0f);
                break;
        }
    }

    //This is called whenever the player collides with a "ontrigger" collision object
    private void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.gameObject.tag == "Player")
        {
            //Update the amount of orbs collected by 1

            //controller.UpdateOrbAmount(controller.GetOrbAmount(OrbElement) + 1, OrbElement);

            switch (powerup)
            {
                case Powerup.DoubleJump:
                    controller.extraJumps = 1;
                    break;

                case Powerup.CharacterGlowing:
                    controller.lumination.enabled = true;
                    break;

                case Powerup.RangedAttack:
                    controller.AttackPowerup = true;
                    break;

                case Powerup.ChargedRangedAttack:
                    controller.ChargeAttackPowerup = true;
                    break;

                case Powerup.Glide:
                    
                    break;

                case Powerup.Dash:
                    controller.DashPowerup = true;
                    print("dash collision");
                    break;
            }

            
            // Delete the Orb
            Destroy(gameObject);
        }
    
     }
}
