using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    private Enemy parent;
    private float nextFireTime = 0.0f;

    void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Defense"))
        {
            parent.target = other.transform;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Defense"))
        {
            return;
        }
        parent.target = other.transform;
        parent.GetComponent<Enemy>().isAttacking = true;
        if (Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1 / parent.attackSpeed;
            parent.attackTarget();
        }

    }
}
