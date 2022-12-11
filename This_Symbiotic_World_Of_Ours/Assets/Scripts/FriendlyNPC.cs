using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class FriendlyNPC : MonoBehaviour
{
    private Dialogue dialogueManager;

    [Header("Dialogue Window settings")]
    public Sprite image;
    public string NPCName;

    [Header("Misc")]
    public bool playerIsClose;
    public bool isWorldSpirit = false;
    [SerializeField] private string[] dialogue;


    private GameObject textObjext;
    private Renderer textRenderer;


    private void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueWindow").GetComponent<Dialogue>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            dialogueManager.setOnLineListener((text) =>
            {
                if (isWorldSpirit && text == "")
                {
                    SceneManager.LoadScene(5);
                } 
            });

            // Sets the values for the dialogue window
            dialogueManager.setImage(image);
            dialogueManager.setNameOfTalker(NPCName);
            dialogueManager.setDialogue(dialogue);
            dialogueManager.ToggleText();
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = true;

            //textObject is child of this object
            textObjext = gameObject.transform.GetChild (0).gameObject;

            textRenderer = textObjext.GetComponent<Renderer>();
            textRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            textRenderer.enabled = false;
            dialogueManager.zeroText();
        }
    }
}
