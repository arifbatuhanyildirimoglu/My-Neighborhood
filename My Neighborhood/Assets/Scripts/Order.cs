using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{

    private Dictionary<GameObject, int> _content;
    private int _price;
    private float _duration;
    private bool isDelivered;
    private Customer _customer;

    public Order()
    {
        _content = new Dictionary<GameObject, int>();
        _price = 0;
        _duration = Random.Range(15,35);
        isDelivered = false;
        _customer = null;
    }
    
    
    public Dictionary<GameObject, int> Content
    {
        get => _content;
        set => _content = value;
    }

    public int Price
    {
        get
        {

            _price = 0;
            
            foreach (KeyValuePair<GameObject, int> keyValuePair in _content)
            {
                GameObject item = keyValuePair.Key;
                int amount = keyValuePair.Value;
                
                _price += item.GetComponent<Item>().GroceryPrice * amount;

            }

            return _price;

        }
    }

    public float Duration => _duration;

    public bool IsDelivered
    {
        get => isDelivered;
        set => isDelivered = value;
    }

    public Customer Customer
    {
        get => _customer;
        set => _customer = value;
    }
}
