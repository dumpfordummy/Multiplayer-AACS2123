using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootRange : MonoBehaviour
{
    private GameObject lootHpBar;

    // Start is called before the first frame update
    void Start()
    {
        lootHpBar = transform.Find("Canvas").gameObject;
        lootHpBar.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lootHpBar.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lootHpBar.SetActive(false);
        }
    }
}
