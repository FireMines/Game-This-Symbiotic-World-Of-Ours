using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [Header("Set by scripts")]
    public GameObject   _Player;
    public GameObject   _Target;
    public float        _ProjectileAcceleration,    // How fast the projectile accelerates towards the enemy.
                        _OrbitAcceleration = 25f,   // How fast the projectile accelerates around the player, while in orbit.
                        _OrbitDeceleration = 0.07f, // How much the projectile decelerates, while in orbit.
                        _OrbitBeginRadius = 1.4f;   // How far away from the player the projectile must be, before starting to orbit.
    public Vector2      _Vel;
    private GameObject  cam;
    private CameraShake cameraShake;

    private bool        launched = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
        cameraShake = cam.GetComponent<CameraShake>();
    }

    private void Update()
    {
        // As long as left mousebutton has NOT been dropped, we don't launch
        if (!Input.GetMouseButton(0) && !launched)
            launched = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move because of velocity
        transform.position += new Vector3(_Vel.x, _Vel.y, 0) * Time.deltaTime;
        transform.right = new Vector3(_Vel.x, _Vel.y, 0);

        // If we haven't launched, orbit the player
        if (!launched)
        {
            // Move with player
            Vector2 playerVel = _Player.GetComponent<Rigidbody2D>().velocity;
            transform.position += new Vector3(playerVel.x, playerVel.y) * Time.deltaTime;

            // Get direction towards player, and if we're too close, don't try to orbit (it crashes the code :( )
            Vector3 dirTowardsPlayer3D = _Player.transform.position - transform.position;
            Vector2 dirTowardsPlayer = new Vector2(dirTowardsPlayer3D.x, dirTowardsPlayer3D.y);
            if (dirTowardsPlayer.magnitude <= _OrbitBeginRadius) return;

            // Accelerate around player...
            Vector2 dirTowardsPlayer_orth = new Vector2(-dirTowardsPlayer.y, dirTowardsPlayer.x);
            float   orbitDirection = Vector2.Dot(_Vel, dirTowardsPlayer_orth);
            _Vel += dirTowardsPlayer_orth * orbitDirection/Mathf.Abs(orbitDirection) * _OrbitAcceleration * Time.deltaTime - _Vel * _OrbitDeceleration;

            // ...and ensure we stay in orbit =)
            Vector2 orbitAcceleration = dirTowardsPlayer.normalized * (Mathf.Pow(_Vel.magnitude, 2) / dirTowardsPlayer.magnitude);
            _Vel += orbitAcceleration * Time.deltaTime;
            return;
        }
        // Otherwise, LAUNCH!

        // If the target is invalid, destroy self.
        if (_Target == null) Destroy(gameObject);

        // Turn towards the target...
        Vector3 dirTowardsTarget = (_Target.transform.position - transform.position).normalized;
        Vector2 dirTowardsTarget_orth2D = new Vector2(-dirTowardsTarget.y, dirTowardsTarget.x);
        _Vel += new Vector2(dirTowardsTarget.x, dirTowardsTarget.y) * _ProjectileAcceleration * Time.deltaTime 
             - dirTowardsTarget_orth2D * Vector2.Dot(dirTowardsTarget_orth2D, _Vel) * 4.3f * Time.deltaTime;

        // vvv IN CASE YOU WANT TO LOCK X AND Y ANGLE vvv
        //Vector3 curRotationAsEuler = transform.rotation.eulerAngles;
        //curRotationAsEuler.x = 0; curRotationAsEuler.y = 0;
        //transform.rotation = Quaternion.Euler(curRotationAsEuler);

        // If we're "touching" the target, hit it
        float distance2 = Vector2.Distance(_Target.transform.position, transform.position);
        if (distance2 <= .5f) HitTarget();
    }

    void HitTarget()
    {
        //CameraShake test;
        //StartCoroutine(test.Shake(1f, 5f));
        //CinemachineShake.Instance.ShakeCamera(5f, 1.1f);
        //if (usedUp == true) return;

        cameraShake.StartShake();

        //usedUp = true;

        //gameObject.SetActive(false);
        Destroy(gameObject);

    }
}
