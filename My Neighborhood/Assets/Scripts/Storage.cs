using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Storage";
        purchasePrice = 30000;
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
