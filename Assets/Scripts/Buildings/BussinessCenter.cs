using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BussinessCenter : Building
{
    void Start()
    {
        name = "Bussiness Center";
        purchasePrice = 200000;
        amount = 50;
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
