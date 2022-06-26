using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour{
    private NavMeshAgent navMeshAgent;
    private GroceryManager groceryManager;
    //[SerializeField] private Transform customerPosition;
    public Vector3 targetPosition;
    void Start(){
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
        
    }

    public void GoToTargetPosition(Vector3 targetPosition){
        navMeshAgent.SetDestination(targetPosition);
    }


}
