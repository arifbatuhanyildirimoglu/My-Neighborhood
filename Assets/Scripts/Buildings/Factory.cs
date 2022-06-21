using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : Building
{
    void Start()
    {
        name = "Factory";
        purchasePrice = 180000;
        amount = 35;
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
