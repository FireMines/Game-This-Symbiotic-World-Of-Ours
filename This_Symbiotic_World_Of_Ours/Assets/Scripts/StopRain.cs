using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopRain : MonoBehaviour
{

    private CharacterController2D player;
    Vector3 cloudPos;

    // Start is called before the first frame update
    void Start()
    {
        cloudPos = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cloudPos.x = player.transform.position.x + 10f;
        cloudPos.y = player.transform.position.y + 30f;
        this.transform.position = cloudPos;
        player.GetTotalOrbAmount();
        ParticleSystem part = GetComponent<ParticleSystem>();

        int orbsCollected = player.GetOrbAmount(OrbController.Element.Water);

        if (orbsCollected >= 3)
            part.Stop();
    }
}
