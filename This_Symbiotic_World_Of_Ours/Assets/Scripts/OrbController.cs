using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;
using TMPro;
using Unity.VisualScripting;

public class OrbController : MonoBehaviour
{
    [Header("Dialogue Window")]
    [SerializeField] private string[] dialogue;
    public Sprite image;

    private Dialogue dialogueManager;

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

    [Header("Orb spesifications")]
    public Element OrbElement;
    public Powerup powerup;

    private CharacterController2D controller;
    private PlayerMovement movement;

    SpriteRenderer sprite;
    ParticleSystem orbLight;


    void Start() 
    {
        // Finds the dialogue window the orbs want to interact with
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueWindow").GetComponent<Dialogue>();


        GameObject[] playerTaggedObjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerTaggedObjects.Length <= 0) Debug.Log("Error fordi det ikke finnes en player??? dette skal egt ikke skje");
        GameObject player = playerTaggedObjects[0];
        controller = player.GetComponent<CharacterController2D>();
        if (controller == null) Debug.Log("Error fordi det ikke finnes en playercontroller??? dette skal egt ikke skje");

        sprite = GetComponentInChildren<SpriteRenderer>();

        orbLight = GetComponentInChildren<ParticleSystem>();

        sprite.sprite = image;

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
            switch (powerup)
            {
                case Powerup.DoubleJump:
                    controller.extraJumps = 1;
                    controller.jumpsLeft = 1;
                    break;

                case Powerup.CharacterGlowing:
                    controller.LightPowerup = true;
                    break;

                case Powerup.RangedAttack:
                    controller.AttackPowerup = true;
                    break;

                case Powerup.ChargedRangedAttack:
                    controller.ChargeAttackPowerup = true;
                    break;

                case Powerup.Glide:
                    controller.GlidePowerup = true;
                    break;

                case Powerup.Dash:
                    controller.DashPowerup = true;
                    break;
            }
            dialogueManager.setOnLineListener((text) =>
            {
            });

            // Sets all the values for the dialogue window for the orbs
            dialogueManager.setImage(image);
            dialogueManager.setNameOfTalker(OrbElement.ToString() + " Fragment");
            dialogueManager.setDialogue(dialogue);
            dialogueManager.ToggleText();
        }


        // Update the amount of orbs collected for each orb type
        controller.UpdateOrbAmount(controller.GetOrbAmount(OrbElement) + 1, OrbElement);

        // Destroys the orb after being picked up
        Destroy(gameObject);
    }
}
     

