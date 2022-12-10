using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class OrbController : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;

    private int index;

    public GameObject continueButton;
    public float wordSpeed;

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

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        Time.timeScale = 1;
        // Delete the Orb
        Destroy(gameObject);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else
        {
            zeroText();
        }
    }


    //This is called whenever the player collides with a "ontrigger" collision object
    private void OnTriggerEnter2D(Collider2D hit)
    {

        if (hit.gameObject.tag == "Player")
        {
            dialogueText.text = "You have gained the " + powerup + " ability!";
            // dialogue = new[] { dialogueText.text };

            //Update the amount of orbs collected by 1
            switch (powerup)
            {
                case Powerup.DoubleJump:
                    controller.extraJumps = 1;
                    controller.jumpsLeft = 1;
                    dialogueText.text += "\nPress SPACE while in air to use the ability.";
                    break;

                case Powerup.CharacterGlowing:
                    controller.LightPowerup = true;
                    dialogueText.text += "\nPress F to toggle the ability.";
                    break;

                case Powerup.RangedAttack:
                    controller.AttackPowerup = true;
                    dialogueText.text += "\nPress LEFT MOUSE BUTTON while near an enemy.";
                    break;

                case Powerup.ChargedRangedAttack:
                    controller.ChargeAttackPowerup = true;
                    dialogueText.text += "\nHold down LEFT MOUSE BUTTON while near an enemy.";
                    break;

                case Powerup.Glide:
                    controller.GlidePowerup = true;
                    dialogueText.text += "\nHold SPACE while in air to use the ability.";
                    break;

                case Powerup.Dash:
                    controller.DashPowerup = true;
                    dialogueText.text += "\nPress SHIFT to use the ability.";
                    break;
            }

            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                continueButton.SetActive(true);
                Time.timeScale = 0;
            }
            //if (continueButton) Time.timeScale = 1;
            print(dialogueText.text);

            // Update the amount of orbs collected for each orb type
            controller.UpdateOrbAmount(controller.GetOrbAmount(OrbElement) + 1, OrbElement);


        }
    
     }
}
