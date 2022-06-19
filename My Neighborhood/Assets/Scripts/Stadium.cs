using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stadium : Building
{
    void Start()
    {
        name = "Stadium";
        purchasePrice = 1000000;
        amount = 500;
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
