using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCompany : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Game Company";
        purchasePrice = 230000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void MakeMoney(float duration, float amount)
    {
        throw new System.NotImplementedException();
    }
}
