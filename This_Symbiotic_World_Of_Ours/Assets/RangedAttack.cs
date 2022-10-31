using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target != null)
        {
            Vector2 targetPosition = new Vector2(Target.transform.position.x, Target.transform.position.y);
            this.transform.LookAt(targetPosition);

            float distance2 = Vector2.Distance(Target.transform.position, this.transform.position);

            if(distance2 > 2f)
            {
                transform.Translate(transform.forward * 30f * Time.deltaTime);
            } else
            {
                HitTarget();
            }
        }
    }

    void HitTarget()
    {
        Destroy(this.gameObject);
    }
}
