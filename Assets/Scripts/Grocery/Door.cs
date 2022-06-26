using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour{
    private Quaternion closedDoorRotation;
    private Quaternion opernDoorRotation;
    void Start()
    {
     closedDoorRotation = Quaternion.Euler(0,0,0);   
     opernDoorRotation = Quaternion.Euler(0,90,0);   
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
