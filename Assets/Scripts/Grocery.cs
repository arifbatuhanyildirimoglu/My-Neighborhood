using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : Building
{

    private Dictionary<Item, int> _stock;
    
    
    void Start()
    {
        name = "Grocery";
        isOwned = true;
    }

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
