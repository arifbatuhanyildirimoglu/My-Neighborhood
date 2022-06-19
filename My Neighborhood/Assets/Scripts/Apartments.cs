using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartments : Building
{
    void Start()
    {
        name = "Apartments";
        purchasePrice = 120000;
        amount = 10;
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
