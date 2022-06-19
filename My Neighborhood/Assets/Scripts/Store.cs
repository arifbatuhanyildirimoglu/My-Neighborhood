using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Building
{
    void Start()
    {
        name = "Store";
        purchasePrice = 80000;
        amount = 100;
        duration = 15;
    }

    void Update()
    {
        if (isOwned && !isMakingMoney)
        {
            isMakingMoney = true;
            StartCoroutine(MakeMoney(duration, amount));
        }
    }

}
