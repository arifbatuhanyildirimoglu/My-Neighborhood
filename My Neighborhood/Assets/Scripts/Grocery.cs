using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grocery : Building
{

    private Dictionary<Item, int> _stock;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MakeMoney(float duration, float amount)
    {
        throw new System.NotImplementedException();
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