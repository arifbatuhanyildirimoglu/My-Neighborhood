using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternationalBank : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "International Bank";
        purchasePrice = 400000;
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
