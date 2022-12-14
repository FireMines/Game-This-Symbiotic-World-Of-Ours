using System.Collections;
using System.Collections.Generic;
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

    bool hei = false;

    // Start is called before the first frame update
    void Start()
    {
        triggerCollider = GetComponent<Collider2D>();
        if (triggerCollider == null) Debug.Log("Error! Couldn't find trigger.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Don't update if we're in a different scene
        /**if (SceneManager.GetActiveScene().name != BelongsToScene)
        {
            print(SceneManager.GetActiveScene().name);
            return;
        }*/


        // Check for collisions with the trigger-box
        List<Collider2D> colliders = new List<Collider2D>();
        Physics2D.OverlapCollider(triggerCollider, TriggerFilter, colliders);

        if (colliders.Count > 0)
        {
            if (!hei)
            {
                ChangeScene();
                hei = true;
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
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
        StartCoroutine(tester2());

        //LoadAllItemsWhenSceneChanges();
        //Scene test;
        // Unload all other scenes that arent DoNotUnload



        // Load scene
        StartCoroutine(tester());

        //SceneManager.UnloadScene(test);
    }

    IEnumerator tester2()
    {
        yield return new WaitForSeconds(0.1F);
        LoadAllItemsWhenSceneChanges();


    }


    IEnumerator tester()
    {
        yield return new WaitForSeconds(0.2F);
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;
            if (SceneManager.GetSceneAt(i).name == SceneToLoad) continue;

            //LoadAllItemsWhenSceneChanges();
            //test = SceneManager.GetSceneAt(i);
            // Unloads all scenes passed through
            SceneManager.UnloadScene(SceneManager.GetSceneAt(i));
        }


    }


    public void LoadAllItemsWhenSceneChanges()
    {
        //GameObject.FindGameObjectsWithTag("Collectable")
        //rock = GameObject.FindGameObjectWithTag("rock").GetComponent<CharacterController2D>();
        //GameObject[] orbsObjects = ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController2D>();
        print(GameObject.FindGameObjectWithTag("Collectable"));
        print("VENTET 3 SEC NÅ");

        foreach (GameObject orbsObject in GameObject.FindGameObjectsWithTag("Collectable"))
        {
            OrbController getOrb = orbsObject.GetComponent<OrbController>();
            print("tihi: " + orbsObject);

            if (getOrb == null) continue;
            orbs.Add(getOrb);
        }

        // Loader alle ting riktig
        //rock.transform.position.x = PlayerPrefs.GetFloat("Rock1x");

        foreach (OrbController orb in orbs)
        {
            print("tihi");
            print(orb);
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



        /*
        // Unload all other scenes that arent DoNotUnload
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;
            
            if (SceneManager.GetActiveScene().name == "FirstEarthLevelScene")
            {
            }
            if (SceneManager.GetActiveScene().name == "FirstWaterLevelScene")
            {
                // Loader alle ting riktig
                //rock.transform.position.x = PlayerPrefs.GetFloat("Rock1x");
                if (player.DashPowerup)
                {
                    foreach (OrbController orb in orbs)
                    {
                        if (orb.powerup == OrbController.Powerup.DoubleJump)
                            Destroy(orb);
                        if (orb.powerup == OrbController.Powerup.Dash)
                            Destroy(orb);
                        if (orb.powerup == OrbController.Powerup.Glide)
                            Destroy(orb);
                    }
                }
            }


        }

        //if Playerprefs.getint(dashorb == 1) for all orbs get powerups;  destroy(orbs.powerup) 
        // else //load som vanlig
        */
    }

    /*
    private void SetAllItemsWhenSceneChanges()
    {
        rock = GameObject.FindGameObjectWithTag("rock").GetComponent<CharacterController2D>();

        // Unload all other scenes that arent DoNotUnload
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;

            if (SceneManager.GetActiveScene().name == "FirstWaterLevelScene")
            {
                // Setter alle ting riktig
                PlayerPrefs.SetFloat("Rock1x", rock.transform.position.x)
            }

        }

        PlayerPrefs.SetInt("d",player.getDashBool())

    }*/

}
