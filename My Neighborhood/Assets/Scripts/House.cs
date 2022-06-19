using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    void Start()
    {
        name = "House";
        purchasePrice = 50000;
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
