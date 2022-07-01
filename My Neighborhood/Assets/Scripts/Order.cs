using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{

    private Dictionary<GameObject, int> _content;
    private int _price;
    private float _duration;
    private bool _isCompleted;

    public Order()
    {
        _content = new Dictionary<GameObject, int>();
        _price = 0;
        _duration = Random.Range(15,35);
        _isCompleted = false;
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

    public bool IsCompleted
    {
        get => _isCompleted;
        set => _isCompleted = value;
    }
}
