using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayPlayerHealth : MonoBehaviour
{
    public Sprite healthSprite;
    public Canvas healthCanvas;
    public Image deathScreen;


    private HealthController characterInfo;    // Character info


    // All Life Cells
    [SerializeField] private List<Image> LifeCells = new List<Image>();


    // Start is called before the first frame update
    void Start()
    {
        RectTransform LifeCell = GetComponent<RectTransform>();
        LifeCell.anchoredPosition = new Vector2(LifeCell.anchoredPosition.x, LifeCell.anchoredPosition.y + 20);
        characterInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();

        //LifeCell = Image.FindObjectOfType();
        //UpdateHealthbar();

        createHealthImageBasedOnHP();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthbar();
    }


    /// <summary>
    /// Creates the amount of Lifecells the player have on screen display
    /// </summary>
    public void createHealthImageBasedOnHP()
    {
        Vector2 lifecellPos;
        lifecellPos.x = Screen.width/2.5f;
        lifecellPos.y = 50;
        for (int i = 0; i < characterInfo.health; i++)
        {
            GameObject NewObj = new GameObject();
            Image LifeCell = NewObj.AddComponent<Image>();
            LifeCell.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(40, 40);
            LifeCell.gameObject.GetComponent<RectTransform>().position = lifecellPos;
            LifeCell.name = "Lifecell_" + i;
            LifeCell.transform.SetParent(healthCanvas.transform);
            lifecellPos.x += 50;
            LifeCell.sprite = healthSprite;
            LifeCells.Add(LifeCell);
        }
    }


    /// <summary>
    /// Updates how much health is left on the player health bar
    /// </summary>
    public void UpdateHealthbar()
    {
        for (int i = 0; i < LifeCells.Count; i++)
        {
            if (i < characterInfo.health)
            {
                //print("i: " + i + "\nhealth: " + characterInfo.getHealth());
                //LifeCells[i].enabled = true;
                LifeCells[i].color = Color.green;
            }
            else
            {
                //LifeCells[i].enabled = false;
                LifeCells[i].color = Color.black;
            }
        }
    }

}
