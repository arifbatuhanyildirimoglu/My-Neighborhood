using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patisserie : Building
{
    void Start()
    {
        name = "Patisserie";
        purchasePrice = 70000;
        amount = 15;
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
