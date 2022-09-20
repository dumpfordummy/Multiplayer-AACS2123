using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Loot
{
    public LootHpBar hpBar;
    public int treeMaxHP;

    // Start is called before the first frame update
    void Start()
    {
        setHp(treeMaxHP);
        hpBar.setHealth(getHp());
    }

    // Update is called once per frame
    void Update()
    {
        if (getHp() <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("WoodResources").GetComponent<woodResources>().addWoodQty(100);
            GameObject.FindGameObjectWithTag("LootSpawner").GetComponent<LootSpawner>().treeCount--;
        }

        hpBar.setHealth(getHp());
    }
}
