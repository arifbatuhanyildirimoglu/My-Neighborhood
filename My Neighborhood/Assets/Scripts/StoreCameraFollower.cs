using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreCameraFollower : MonoBehaviour
{
    
    [SerializeField]private Transform target;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = target.position;
        transform.rotation = Quaternion.LookRotation(-target.forward);
    }
}
