using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform target;
    public float attackSpeed = 1;
    public float damage = 10f;
    private EnemyHp getHp;

    public void attackTarget()
    {
        if(target != null)
        {
            target.GetComponent<EnemyHp>().DecreaseEntityHp(damage);
        }
    }
}
