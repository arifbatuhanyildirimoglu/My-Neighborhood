using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryManager : MonoBehaviour
{
    [SerializeField]private GameObject customerModel;
    [SerializeField]private Transform[] customerSpawnPositions;
    [SerializeField]private Material[] customerMaterials;
    [SerializeField] private bool isOpen;
    [SerializeField] private bool isCustomerComing;
    private GroceryManager instance;
    void Start()
    {
        if (instance == null){
            instance = this;
        }

        StartCoroutine(CreateDelayedCustomer());
    }

    
    void Update()
    {
        
    }

    public void CreateCustomer(){
        int randomPositionNumber = Random.Range(0, 2);
        GameObject currentCustomer = Instantiate(customerModel, customerSpawnPositions[randomPositionNumber].position, Quaternion.identity);
        
        for (int i = 0; i < currentCustomer.transform.GetChild(0).childCount - 1; i++){
            int randomNumber = Random.Range(0, 8);
            currentCustomer.transform.GetChild(0).GetChild(i).GetComponent<SkinnedMeshRenderer>().material = customerMaterials[randomNumber];
        }
        
        
        Customer customer = currentCustomer.GetComponent<Customer>();
        Vector3 targetPosition = randomPositionNumber == 0 ? customerSpawnPositions[1].position : customerSpawnPositions[0].position;
        Debug.Log(targetPosition);
        customer.GoToTargetPosition(targetPosition);
    }

    IEnumerator CreateDelayedCustomer(){
        while (true){
            CreateCustomer();
            Debug.Log("Created");
            float randomDelayTime = Random.Range(3, 7);
            yield return new WaitForSeconds(randomDelayTime); 
        }
            
    }
}
