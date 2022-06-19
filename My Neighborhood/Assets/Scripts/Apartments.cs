using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apartments : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Apartments";
        purchasePrice = 120000;
        amount = 10;
        duration = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOwned && !isMakingMoney)
        {
            isMakingMoney = true;
            StartCoroutine(MakeMoney(duration, amount));
        }
    }

}
