using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRain : MonoBehaviour
{

    private CharacterController2D player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        player.GetTotalOrbAmount();
        ParticleSystem part = GetComponent<ParticleSystem>();

        int orbsCollected = player.GetOrbAmount(OrbController.Element.Water);

        if (orbsCollected >= 3)
            part.Stop();
    }
}
