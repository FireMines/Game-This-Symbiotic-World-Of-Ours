using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public enum Element{
    Water,
    Earth
    }

    public Element OrbElement;

    private CharacterController2D controller;

    void Start() {
        GameObject[] playerTaggedObjects = GameObject.FindGameObjectsWithTag("Player");
        if (playerTaggedObjects.Length <= 0) Debug.Log("Error fordi det ikke finnes en player??? dette skal egt ikke skje");
        GameObject player = playerTaggedObjects[0];
        controller = player.GetComponent<CharacterController2D>();
        if (controller == null) Debug.Log("Error fordi det ikke finnes en playercontroller??? dette skal egt ikke skje");
    }

    private void OnTriggerEnter2D(Collider2D other){

        //Update the amount of orbs collected by 1
        
        controller.UpdateOrbAmount(controller.GetOrbAmount(OrbElement)+1, OrbElement);

        Debug.Log(controller.GetOrbAmount(OrbElement).ToString());
        Debug.Log(OrbElement.ToString());
        
        // Delete the Orb
        Destroy(gameObject);
    
   }
}
