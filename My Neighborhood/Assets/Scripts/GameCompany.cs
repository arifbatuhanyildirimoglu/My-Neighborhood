using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompany : Building
{
    void Start()
    {
        name = "Game Company";
        purchasePrice = 230000;
        amount = 20;
        duration = 20;
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
