using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class stoneResources : MonoBehaviour
{
    public int stoneQty = 0;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = stoneQty.ToString();
    }

    public void addStoneQty(int stoneQty)
    {
        this.stoneQty += stoneQty;
    }

    public void decStoneQty(int stoneQty)
    {
        if (stoneQty <= this.stoneQty)
        {
            this.stoneQty -= stoneQty;
        }
        else
            return;
    }

    public int getStoneQty()
    {
        return this.stoneQty;
    }
}
