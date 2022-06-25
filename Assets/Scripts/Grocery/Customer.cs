using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour{
    private NavMeshAgent navMeshAgent;
    private GroceryManager groceryManager;
    public Transform targetPosition;
    void Start(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
        
    }


}
