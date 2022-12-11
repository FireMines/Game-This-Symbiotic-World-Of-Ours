using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossfadeScript : MonoBehaviour
{
    private Animator animationController;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<Animator>();
        if (animationController == null) Debug.Log("Error! Crossfade doesn't have an animation controller.");
    }

    public void StartCrossfade()
    {
        animationController.SetTrigger("Start");
    }
}
