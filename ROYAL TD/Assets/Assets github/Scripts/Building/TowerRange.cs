using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    private TowerAttack parent;
    private float nextFireTime = 0.0f;

    void Start()
    {
        parent = GetComponentInParent<TowerAttack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            parent.target = other.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (parent.target == null)
        {
            parent.target = other.transform;
        }

        if (!other.gameObject.CompareTag("Enemy"))
        {
            parent.target = null;
            return;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + 1 / parent.attackSpeed;
                parent.attackTarget();
            }
        }
    }


}
