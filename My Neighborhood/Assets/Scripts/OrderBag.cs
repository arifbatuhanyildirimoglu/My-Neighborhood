using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class OrderBag : MonoBehaviour
{
    private Dictionary<GameObject, int> _content;
    private bool _isAbleToDeliver;
    Vector3[] _path = new Vector3[4];


    private void Start()
    {
        _content = new Dictionary<GameObject, int>();
        _isAbleToDeliver = false;
    }

    private void Update()
    {
        SetAbleToDeliver();
    }

    public void Deliver()
    {
        if(!_isAbleToDeliver)
            return;
        
        //TODO: customer geri gidecek. +
        //TODO: order ve orderBag temizlenecek +
        //TODO: order price bakiyeye eklenecek. +
        //TODO: diğer customer gelecek. -


        _path[0] = new Vector3(-18.32f,0.5f,-11.62f);
        _path[1] = new Vector3(-15.32f,0.5f,-11.62f);
        _path[2] = new Vector3(-15.3f,0.5f,-2.5f);
        _path[3] = new Vector3(-8, 0.5f, -2.5f);

        //Order'daki ürünleri stocktan silme

        foreach (KeyValuePair<GameObject, int> keyValuePair in GroceryManager.Instance.CurrentOrder.Content)
        {
            string name = keyValuePair.Key.name;

            foreach (KeyValuePair<string, int> stockPair in Grocery.Instance.Stock)
            {
                string key = stockPair.Key;
                int value = stockPair.Value;
                
                if (key.Equals(name))
                {
                    value -= keyValuePair.Value;
                    Grocery.Instance.Stock.Remove(key);
                    Grocery.Instance.Stock.Add(key, value);
                    break;
                }
            }
            
        }
        
        Player.Instance.Budget += GroceryManager.Instance.CurrentOrder.Price;
        GroceryManager.Instance.CurrentOrder = null;
        _content = new Dictionary<GameObject, int>();
        GroceryManager.Instance.CurrentCustomer.transform.DOPath(_path, 10f)
            .OnWaypointChange(Look)
            .OnComplete(CreateOtherCustomer);
        GroceryManager.Instance.CurrentCustomer.GetComponent<Animator>().SetBool("isWalking",true);
        
    }

    private void SetAbleToDeliver()
    {
        
        //if(order.content == this.content)
        //  isAbleToDeliver = true;

        if(GroceryManager.Instance.CurrentOrder == null)
            return;
        
        if (GroceryManager.Instance.CurrentOrder.Content == _content)
            _isAbleToDeliver = true;
        
    }

    void Look(int index)
    {
        GroceryManager.Instance.CurrentCustomer.transform.LookAt(_path[index]);
    }

    void CreateOtherCustomer()
    {
        
        Destroy(GroceryManager.Instance.CurrentCustomer);
        
        GroceryManager.Instance.CreateCustomer();

    }

    public Dictionary<GameObject, int> Content
    {
        get => _content;
        set => _content = value;
    }

    public bool IsAbleToDeliver => _isAbleToDeliver;
}
