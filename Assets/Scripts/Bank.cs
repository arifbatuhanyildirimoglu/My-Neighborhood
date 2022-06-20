using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : Building
{
    void Start()
    {
        name = "Bank";
        purchasePrice = 150000;
        amount = 20;
        duration = 10;
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
