using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : Building
{

    private Dictionary<Item, int> _stock;
    
    
    // Start is called before the first frame update
    void Start()
    {
        name = "Grocery";
        isOwned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOwned && !isMakingMoney)
        {
            isMakingMoney = true;
            StartCoroutine(MakeMoney(duration, amount));
        } 
    }

    private void AddToStock(Item item)
    {
        
    }

    private void AddToStock(Dictionary<Item, int> items)
    {
        
        
        
    }

    private void UpdateMoneyRate()
    {
        
        //itemların miktarı sıfır oldukça helen parayı düşür
        //her sıfır için -1.5 mesela
        
        
        
    }
    
}
