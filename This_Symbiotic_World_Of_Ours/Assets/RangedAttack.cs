using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [Header("Set by scripts")]
    public GameObject   _Target;
    public float        _ProjectileAcceleration;
    public Vector2      _Vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the target is invalid, destroy self.
        if (_Target == null) Destroy(gameObject);

        // Turn towards the target...
        Vector3 dirTowardsTarget = (_Target.transform.position - transform.position).normalized;
        transform.right = dirTowardsTarget;
        Vector2 dirTowardsTarget_orth2D = new Vector2(-dirTowardsTarget.y, dirTowardsTarget.x);
        _Vel += new Vector2(dirTowardsTarget.x, dirTowardsTarget.y) * _ProjectileAcceleration * Time.deltaTime 
             - dirTowardsTarget_orth2D * Vector2.Dot(dirTowardsTarget_orth2D, _Vel) * 4.3f * Time.deltaTime;

        // vvv IN CASE YOU WANT TO LOCK X AND Y ANGLE vvv
        //Vector3 curRotationAsEuler = transform.rotation.eulerAngles;
        //curRotationAsEuler.x = 0; curRotationAsEuler.y = 0;
        //transform.rotation = Quaternion.Euler(curRotationAsEuler);

        // If we're "touching" the target, hit it
        float distance2 = Vector2.Distance(_Target.transform.position, transform.position);
        if (distance2 <= 2f) HitTarget();

        // Otherwise, move towards it
        else transform.position += new Vector3(_Vel.x, _Vel.y, 0) * Time.deltaTime; //transform.Translate(transform.right * _ProjectileSpeed * Time.deltaTime);
    }

    void HitTarget()
    {
        Destroy(gameObject);
    }
}
