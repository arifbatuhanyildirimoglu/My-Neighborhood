using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaCompany : Building
{
    void Start()
    {
        name = "Media Company";
        purchasePrice = 215000;
        amount = 35;
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
