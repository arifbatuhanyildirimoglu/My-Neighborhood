using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    private float _budget;

    public float Budget
    {
        get => _budget;
        set => _budget = value;
    }
    
    private Player(){}
    
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        
        Instance = this;
        
        _budget = 15000;
    }

    void Update()
    {
        
    }

    public bool Purchase(Building building)
    {
        if (building.PurchasePrice > _budget)
            return false;
        
        building.IsOwned = true;
        _budget -= building.PurchasePrice;
        return true;

    }
}
