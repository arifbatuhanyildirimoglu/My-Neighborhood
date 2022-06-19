using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Building
{
    void Start()
    {
        name = "Storage";
        purchasePrice = 30000;
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
