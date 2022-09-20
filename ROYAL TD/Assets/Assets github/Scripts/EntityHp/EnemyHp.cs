using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    public EnemyHpBar healthBar;
    private Enemy enemy;
    private float dieCountDown = 1;

    private void Start()
    {
        currentHp = maxHp;
        healthBar.setMaxHealth(maxHp);
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (currentHp <= 0)
        {
            GetComponentInParent<Enemy>().target = null;
            GetComponentInParent<Enemy>().isAllive = false;
            GetComponentInParent<Enemy>().SetAnimations(2);
            if (dieCountDown > 0)
            {
                dieCountDown -= Time.deltaTime;
            }
            else if (dieCountDown <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void DecreaseEntityHp(float hpToDecrease)
    {

        currentHp -= hpToDecrease;
        healthBar.setHealth(currentHp);
    }
}

