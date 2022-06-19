using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warehouse : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Warehouse";
        purchasePrice = 40000;
        amount = 5;
        duration = 15;
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
