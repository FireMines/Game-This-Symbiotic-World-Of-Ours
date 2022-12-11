using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    [Header("Particle settings")]
    public GameObject   Particle;
    public Vector3      StartVelocity;
    public  float       timeBetweenSpawns = 1f;

    private float       timeSinceLastSpawn = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= timeBetweenSpawns)
        {
            timeSinceLastSpawn = 0;

            GameObject spawnedParticle = Instantiate(Particle, transform.position, Quaternion.identity);
            Rigidbody2D spawnedParticleRB = spawnedParticle.GetComponent<Rigidbody2D>();
            spawnedParticleRB.velocity = StartVelocity;
        }
    }
}
