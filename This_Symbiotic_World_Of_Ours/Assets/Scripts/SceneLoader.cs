using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class for loading scenes.
/// </summary>
public class SceneLoader : MonoBehaviour
{
    // Public variables
    [Header("Scenes and filter")]
    public string           SceneToLoad,
                            BelongsToScene;
    public ContactFilter2D  TriggerFilter;

    // Private variables
    private Collider2D  triggerCollider;

    private CharacterController2D player;
    private List<OrbController> orbs = new List<OrbController>();

    public static SceneLoader Instance { get; private set; }

    bool sceneLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        if (triggerCollider == null) Debug.Log("Error! Couldn't find trigger.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // Check for collisions with the trigger-box
        List<Collider2D> colliders = new List<Collider2D>();
        Physics2D.OverlapCollider(triggerCollider, TriggerFilter, colliders);

        if (colliders.Count > 0)
        {
            if (!sceneLoaded)
            {
                ChangeScene();
                sceneLoaded = true;
            }
        }
    }


    /// <summary>
    /// Changes the scene to the next scene.
    /// </summary>
    private void ChangeScene()
    {
        // Find crossfade
        GameObject[] crossfadeObjects = GameObject.FindGameObjectsWithTag("Crossfade");
        if (crossfadeObjects.Length > 0)
        {
            CrossfadeScript crossfade = crossfadeObjects[0].GetComponent<CrossfadeScript>();
            crossfade.StartCrossfade();
        }

        //Loads scene
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);

        //loads item changes
        StartCoroutine(loadItems());

        //Unloads unused scenes after loading items
        StartCoroutine(unloadScenes());
    }

    /// <summary>
    /// Loads the items of the scene
    /// </summary>
    IEnumerator loadItems()
    {
        yield return new WaitForSeconds(0.01F);
        LoadAllItemChanges();
    }

    /// <summary>
    /// Unloads scenes after att items are loaded
    /// </summary>
    IEnumerator unloadScenes()
    {
        yield return new WaitForSeconds(0.02F);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;
            if (SceneManager.GetSceneAt(i).name == SceneToLoad) continue;

            // Unloads all scenes passed through
            SceneManager.UnloadScene(SceneManager.GetSceneAt(i));
        }


    }

    /// <summary>
    /// Loads changes that has happened to items in the scene
    /// </summary>
    public void LoadAllItemChanges()
    {
        
        //finds player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();

        //Iterates orbs
        foreach (GameObject orbsObject in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            OrbController getOrb = orbsObject.GetComponent<OrbController>();

            //Checks if orbcontroller is null
            if (getOrb == null) continue;

            //if orb controller exists add it to orbs list
            orbs.Add(getOrb);
        }

        //Iterates all the orbs found
        foreach (OrbController orb in orbs)
        {
            //Checks if a player has the power assosiated with the orbs and deletes it if the player has the power
            if (player.AttackPowerup && orb.powerup == OrbController.Powerup.RangedAttack)
                Destroy(orb.gameObject);

            if (player.ChargeAttackPowerup && orb.powerup == OrbController.Powerup.ChargedRangedAttack)
                Destroy(orb.gameObject);

            if (player.LightPowerup && orb.powerup == OrbController.Powerup.CharacterGlowing)
                Destroy(orb.gameObject);

            if (player.extraJumps > 0 && orb.powerup == OrbController.Powerup.DoubleJump)
                Destroy(orb.gameObject);

            if (player.GlidePowerup && orb.powerup == OrbController.Powerup.Glide)
                Destroy(orb.gameObject);

            if (player.DashPowerup && orb.powerup == OrbController.Powerup.Dash)
                Destroy(orb.gameObject);

        }

    }

}
