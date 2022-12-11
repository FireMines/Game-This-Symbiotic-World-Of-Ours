using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopRain : MonoBehaviour
{

    private CharacterController2D player;
    Vector3 cloudPos;
    Scene currentScene = SceneManager.GetActiveScene();
    ParticleSystem part; 

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();

        // Unload all other scenes that arent DoNotUnload
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "FirstWaterLevelScene") part.Stop();

            if (SceneManager.GetSceneAt(i).name == "FirstEarthLevelScene") part.Play();

        }


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

        int waterOrbsCollected = player.GetOrbAmount(OrbController.Element.Water);
        if (waterOrbsCollected >= 3)
            part.Stop();

        int earthOrbsCollected = player.GetOrbAmount(OrbController.Element.Earth);
        if (earthOrbsCollected >= 3)
            part.Play();
    }
}
