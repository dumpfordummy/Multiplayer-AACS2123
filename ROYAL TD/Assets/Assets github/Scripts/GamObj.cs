using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamObj : MonoBehaviour
{
    public string gameObjectName;
    public int hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setGameObjectName(string gameObjectName)
    {
        this.gameObjectName = gameObjectName;
    }

    public string getGameObjectName()
    {
        return gameObjectName;
    }
    public void setHp(int hp)
    {
        this.hp = hp;
    }

    public int getHp()
    {
        return hp;
    }

    public void receiveDamage(int dmgPerHit)
    {
        hp = hp - dmgPerHit;
    }
}
