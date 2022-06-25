using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryManager : MonoBehaviour
{
    [SerializeField]private GameObject customerModel;
    [SerializeField]private Transform[] customerSpawnPositions;
    [SerializeField]private Material[] customerMaterials;
    [SerializeField] private bool isOpen;
    private GroceryManager instance;
    void Start()
    {
        if (instance == null){
            instance = this;
        }
    }

    
    void Update()
    {
        
    }

    public void CreateCustomer(){
        int randomPositionNumber = Random.Range(0, 2);
        GameObject currentCustomer = Instantiate(customerModel, customerSpawnPositions[randomPositionNumber].position, Quaternion.identity);
        customerModel.GetComponent<Customer>().targetPosition = customerSpawnPositions[(randomPositionNumber) => {}];
        for (int i = 0; i < currentCustomer.transform.childCount - 1; i++){
            int randomNumber = Random.Range(0, 8);
            currentCustomer.transform.GetChild(i).GetComponent<MeshRenderer>().material = customerMaterials[randomNumber];
        }
    }
    
    
}
