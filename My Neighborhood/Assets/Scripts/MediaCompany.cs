using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediaCompany : Building
{
    // Start is called before the first frame update
    void Start()
    {
        name = "Media Company";
        purchasePrice = 215000;
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
