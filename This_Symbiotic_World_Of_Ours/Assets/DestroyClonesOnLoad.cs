using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClonesOnLoad : MonoBehaviour
{
    public static List<DestroyClonesOnLoad> instances;

    private void Awake()
    {
        // Check if we are a clone
        DestroyClonesOnLoad instance = checkIfAlreadyExists();

        // If we're the original, add us to the "keep" list.
        if (instance == null)
        {
            if (instances == null)
                instances = new List<DestroyClonesOnLoad> { this };
            else
                instances.Add(this);
            DontDestroyOnLoad(gameObject);
        }
        // Otherwise, if we're the reference stored within the DontDestroyOnLoad-scene, replace the old with us >:)
        else
        {
            transform.position = instance.transform.position;

            instances.Remove(instance);
            Destroy(instance.gameObject);

            DontDestroyOnLoad(gameObject);
            instances.Add(this);
        }
    }

    /// <summary>
    /// Checks if a gameobject with this gameobject's name already exists.
    /// </summary>
    /// <returns>True if a gameobject with this ones name already exists.</returns>
    DestroyClonesOnLoad checkIfAlreadyExists()
    {
        if (instances == null) return null;
        foreach (DestroyClonesOnLoad instance in instances)
        {
            GameObject gameObject = instance.gameObject;
            if (gameObject.name == name)
                return instance;
        }
        return null;
    }
}
