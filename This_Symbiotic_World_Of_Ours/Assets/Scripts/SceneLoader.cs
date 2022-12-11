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
            ChangeScene();
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

        // Unload all other scenes that arent DoNotUnload
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            // Skips unloading if its in the DoNotUnload Scene
            if (SceneManager.GetSceneAt(i).name == "DoNotUnload") continue;


            // Unloads all scenes passed through
            SceneManager.UnloadScene(SceneManager.GetSceneAt(i));
        }

        // Load scene
        SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Additive);
    }
}
