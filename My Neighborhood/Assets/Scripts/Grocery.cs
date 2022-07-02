using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grocery : Building
{

    public static Grocery Instance;
    
    private Dictionary<string, int> _stock;
    
    
    private Grocery(){}
    
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        name = "Grocery";
        isOwned = true;

        _stock = new Dictionary<string, int>();
        _stock.Add("Apple",0);
        _stock.Add("Avocado",0);
        _stock.Add("Beer",0);
        _stock.Add("Canned Food",0);
        _stock.Add("Carrot",0);
        _stock.Add("Cola",0);
        _stock.Add("Egg",0);
    }

    void Update()
    {
        if (!SceneManager.GetActiveScene().name.Equals("SampleScene"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        /*
        if (isOwned && !isMakingMoney)
        {
            isMakingMoney = true;
            StartCoroutine(MakeMoney(duration, amount));
        } 
        */
    }

    private void AddToStock(string itemName, int amount)
    {
        _stock.Add(itemName,amount);
    }

    private void AddToStock(Dictionary<string, int> items)
    {

        foreach (string itemName in items.Keys)
        {
            
            _stock.Add(itemName, items[itemName]);
            
        }
        
    }
    
    public Dictionary<string, int> Stock
    {
        get => _stock;
        set => _stock = value;
    }
    
}
