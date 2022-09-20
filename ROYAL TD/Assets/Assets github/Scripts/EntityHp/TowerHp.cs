using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHp : MonoBehaviour
{
    public static event Action OnTownHallDestroy;
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;
    public TowerHpBar hpBar;
    public static bool isInitializing = false;

    private void Start()
    {
        currentHp = maxHp;
        hpBar.setMaxHealth(maxHp);
    }

    public void DecreaseEntityHp(Transform enemy, float hpToDecrease)
    {
        currentHp -= hpToDecrease;

        if (currentHp <= 0)
        {
            if (name == "TownHall")
            {
                currentHp = 0;
                Debug.Log("Game Over!");
                OnTownHallDestroy?.Invoke();
            }

            CleanUp(enemy);
            Destroy(gameObject);
        }

        hpBar.setHealth(currentHp);
    }

    public void CleanUp(Transform enemy)
    {
        isInitializing = true;
        if (Pathfinding.obstacleList == null)
        {
            // THIS IS THE END OF GAME
            return;
        }
        foreach (PathNode node in Pathfinding.obstacleList)
        {
            GridBase<PathNode>.GetXY(GetComponent<Transform>().position, out int x, out int y);
            if (node.x == x && node.y == y)
            {
                Pathfinding.obstacleList.Remove(node);
                break;
            }
        }

        enemy.gameObject.GetComponent<EnemyMovement>().InitializeMovement();

        if (TryGetComponent<TowerAttack>(out var target))
        {
            target.target = null;
        }

        isInitializing = false;
    }
}
