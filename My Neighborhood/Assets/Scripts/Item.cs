using System;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected int storePrice;
    protected int groceryPrice;
    protected bool isDeployedToCart = false;

    public bool IsDeployedToCart
    {
        get => isDeployedToCart;
        set => isDeployedToCart = value;
    }

}