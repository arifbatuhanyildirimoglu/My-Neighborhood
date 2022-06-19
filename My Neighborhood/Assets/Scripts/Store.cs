using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Store";
        purchasePrice = 80000;
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
