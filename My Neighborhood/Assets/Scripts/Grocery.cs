using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grocery : Building
{

    private Dictionary<Item, int> _stock;
    
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        name = "Grocery";
        isOwned = true;

        _stock = new Dictionary<Item, int>();
    }

    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
        if (isOwned && !isMakingMoney)
        {
            isMakingMoney = true;
            StartCoroutine(MakeMoney(duration, amount));
        } 
    }

    private void AddToStock(Item item, int amount)
    {
        _stock.Add(item,amount);
    }

    private void AddToStock(Dictionary<Item, int> items)
    {

        foreach (Item item in items.Keys)
        {
            
            _stock.Add(item, items[item]);
            
        }
        
    }

    private void UpdateMoneyRate()
    {
        
        //itemların miktarı sıfır oldukça helen parayı düşür
        //her sıfır için -1.5 mesela
        
        
        
    }
    
}
