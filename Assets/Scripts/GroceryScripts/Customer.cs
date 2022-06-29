using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour{
    private NavMeshAgent navMeshAgent;
    private GroceryManager groceryManager;
    public bool IsCustomerGoingToGrocery{ get; set;}
    private Animator animator;
    
    public Vector3 targetPosition;
    void Start(){
        IsCustomerGoingToGrocery = false;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    
    void Update()
    {
        
        
    }

    public void GoToTargetPosition(Vector3 targetPosition){
        navMeshAgent.SetDestination(targetPosition);
        
        if (navMeshAgent.isStopped == false){
            animator.SetBool("isWalking", true);
        }
        else{
            animator.SetBool("isWalking", false);
        }
    }

    public void CustomerGiveOrder()
    {

    }

    public void CreateOrder()
    {

    }
    
}
