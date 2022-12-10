using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRocksAttackable : MonoBehaviour
{
    private CharacterController2D characterInfo;    // Character info
    private GameObject[] stoneWall;                 // StoneWall blocking the way for the player

    // Start is called before the first frame update
    void Start()
    {
        characterInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gets total amount of orbs collected
        int orbsCollected = characterInfo.GetTotalOrbAmount();

        // If player havent collected all orbs, return
        if (orbsCollected != 6) return;

        // Find all stonewalls/ rocks that needs to become attackable and tag them as Enemy
        stoneWall = GameObject.FindGameObjectsWithTag("NotYetAttackableRock");
        foreach(GameObject stone in stoneWall)
        {
            stone.transform.gameObject.tag = "Enemy";
        }
    }
}
