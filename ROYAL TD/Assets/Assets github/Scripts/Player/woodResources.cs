using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class woodResources : MonoBehaviour
{
    public int woodQty;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = woodQty.ToString();
    }

    public void addWoodQty(int woodQty)
    {
        this.woodQty += woodQty;
    }

    public void decWoddQty(int woodQty)
    {
        if (woodQty <= this.woodQty)
        {
            this.woodQty -= woodQty;
        }
        else
            return;
    }

    public int getWoodQty()
    {
        return this.woodQty;
    }
}
