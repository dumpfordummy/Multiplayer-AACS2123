using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        TowerHp.OnTownHallDestroy += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        TowerHp.OnTownHallDestroy -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
