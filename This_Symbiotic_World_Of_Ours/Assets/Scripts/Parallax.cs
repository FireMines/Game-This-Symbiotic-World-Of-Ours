using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startx;
    private float height, starty;
    private GameObject cam;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        startx = transform.position.x;
        starty = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float distx = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y);
        
        transform.position = new Vector3(startx + distx, disty, transform.position.z);

        if (temp > startx + length) startx += length;
        else if (temp < startx - length) startx -= length;
    }
}
