using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternationalBank : Building
{
    void Start()
    {
        name = "International Bank";
        purchasePrice = 400000;
        amount = 100;
        duration = 5;
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
