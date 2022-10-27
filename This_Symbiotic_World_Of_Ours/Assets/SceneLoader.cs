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
    public string           SceneToLoad,
                            BelongsToScene;
    public LoadSceneMode    SceneLoadMode = LoadSceneMode.Single;
    public GameObject[]     DontDestroy;
    public ContactFilter2D  TriggerFilter;

    // Private variables
    private Collider2D  triggerCollider;
    private AsyncOperation sceneAsync;

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
        if (SceneManager.GetActiveScene().name != BelongsToScene) return;

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

        // Load scene
        SceneManager.LoadScene(SceneToLoad, SceneLoadMode);
    }
}
