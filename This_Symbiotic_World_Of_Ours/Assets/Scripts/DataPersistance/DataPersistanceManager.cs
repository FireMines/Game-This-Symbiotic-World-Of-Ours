using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    //private GameData gameData;

    CharacterController2D player;

    public static DataPersistanceManager Instance { get; private set; }

    public void LoadGameData()
    {
        
    }

    public void SaveGameData()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        GameObject[] pushableRocks = GameObject.FindGameObjectsWithTag("Pushable");
        GameObject[] pushableTree = GameObject.FindGameObjectsWithTag("PushableTree");
        GameObject[] water = GameObject.FindGameObjectsWithTag("Water");


        
            
      

    }

}
