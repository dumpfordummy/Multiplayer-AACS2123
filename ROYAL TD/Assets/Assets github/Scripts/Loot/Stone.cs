using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Loot
{
    public LootHpBar hpBar;
    public int stoneMaxHP;

    // Start is called before the first frame update
    void Start()
    {
        setHp(stoneMaxHP);
        hpBar.setHealth(getHp());
    }

    // Update is called once per frame
    void Update()
    {
        if (getHp() <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("StoneResources").GetComponent<stoneResources>().addStoneQty(100);
            GameObject.FindGameObjectWithTag("LootSpawner").GetComponent<LootSpawner>().stoneCount--;
        }

        hpBar.setHealth(getHp());
    }
}
