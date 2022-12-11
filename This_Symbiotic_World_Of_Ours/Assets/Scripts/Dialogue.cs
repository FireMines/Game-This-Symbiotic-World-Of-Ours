using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    [Header("Setup")]
    public GameObject DialoguePanel;
    public GameObject ContinueButton;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NameOfTalker;
    public GameObject image;
    public float WordSpeed;

    private string[] dialogue;
    private int index;

    private Action<string> onLineListener = null;

    // Update is called once per frame
    void Update()
    {
        if (dialogue == null) return;
        if (DialogueText == null) return;


        if (DialogueText.text == dialogue[index])
        {
            ContinueButton.SetActive(true);
        }
    }

    public void zeroText()
    {
        DialogueText.text = "";
        index = 0;
        DialoguePanel.SetActive(false);
    }

    public IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(WordSpeed);
        }
    }

    public void NextLine()
    {
        ContinueButton.SetActive(false);

        if (index < dialogue.Length - 1)
        {
            index++;
            if(onLineListener != null) onLineListener(dialogue[index]);
            DialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
            if (onLineListener != null) onLineListener("");
            
        }
    }


    public void setOnLineListener(Action<string> callback = null)
    {
        onLineListener = callback;
    }

    /// <summary>
    /// Toggles the text to either open and start typing or close the text window
    /// </summary>
    public void ToggleText()
    {
        if (DialoguePanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            DialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }


    /// <summary>
    /// Sets the dialogue
    /// </summary>
    /// <param name="sentences">Dialogue from a particular element</param>
    public void setDialogue(string[] sentences)
    {
        dialogue = sentences;
    }


    /// <summary>
    /// Sets the name of element you have a dialog with
    /// </summary>
    /// <param name="name">Name of element you are interacting with</param>
    public void setNameOfTalker(string name)
    {
        NameOfTalker.SetText(name);
    }

    
    /// <summary>
    /// Set the image of the element you have a dialog with
    /// </summary>
    /// <param name="picture">Image of element you are interacting with</param>
    public void setImage(Sprite picture)
    {
        image.GetComponent<Image>().sprite = picture;
    }

}
