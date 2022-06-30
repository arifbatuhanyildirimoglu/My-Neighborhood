using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderBag : MonoBehaviour
{
    private Dictionary<GameObject, int> _content;
    private bool _isAbleToDeliver;


    private void Start()
    {
        _content = new Dictionary<GameObject, int>();
        _isAbleToDeliver = false;
    }

    private void Update()
    {
        SetAbleToDeliver();
    }

    private void Deliver()
    {
        if(!_isAbleToDeliver)
            return;
        
    }

    private void SetAbleToDeliver()
    {
        
        //if(order.content == this.content)
        //  isAbleToDeliver = true;

        if (GroceryManager.Instance.CurrentOrder.Content == _content)
            _isAbleToDeliver = true;
        
        Debug.Log(_isAbleToDeliver);

    }

    public Dictionary<GameObject, int> Content
    {
        get => _content;
        set => _content = value;
    }

    public bool IsAbleToDeliver => _isAbleToDeliver;
}
