using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : Building
{
    void Start()
    {
        name = "Warehouse";
        purchasePrice = 40000;
        amount = 5;
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
