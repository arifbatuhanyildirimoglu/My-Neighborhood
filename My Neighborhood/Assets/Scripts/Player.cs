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
    
    // Start is called before the first frame update
    void Start()
    {

        Instance = this;
        
        _budget = 15000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Purchase(Building building)
    {
        
        building.IsOwned = true;
        _budget -= building.PurchasePrice;

    }
}
