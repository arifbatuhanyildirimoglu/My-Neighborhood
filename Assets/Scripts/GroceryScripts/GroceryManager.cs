using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GroceryManager : MonoBehaviour
{
    [SerializeField]private GameObject customerModel;
    [SerializeField]private Transform[] customerSpawnPositions;
    [SerializeField]private Material[] customerMaterials;
    [SerializeField]private bool isOpen;
    [SerializeField]private bool isCustomerComing;
    [SerializeField] private Transform customerPosition;
    private GroceryManager instance;
    private List<GameObject> customerList = new List<GameObject>();

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isOpen = true;
        isCustomerComing = false;
        StartCoroutine(CreateDelayedCustomer());
        StartCoroutine(SendDelayedCustomerToGrocery());
        StartCoroutine(DestroyDelayedCustomer());
    }

    
    void Update()
    {
        
    }

    public void CreateCustomer(){
        int randomPositionNumber = Random.Range(0, 2);
        GameObject currentCustomer = Instantiate(customerModel, customerSpawnPositions[randomPositionNumber].position, Quaternion.identity);
        customerList.Add(currentCustomer);
        
        for (int i = 0; i < currentCustomer.transform.GetChild(0).childCount - 1; i++){
            int randomNumber = Random.Range(0, 8);
            currentCustomer.transform.GetChild(0).GetChild(i).GetComponent<SkinnedMeshRenderer>().material = customerMaterials[randomNumber];
        }
        
        Customer customer = currentCustomer.GetComponent<Customer>();
        Vector3 targetPosition = randomPositionNumber == 0 ? customerSpawnPositions[0].position : customerSpawnPositions[1].position;
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

    public void SendCustomerToGrocery(){
        Customer customer = customerList[customerList.Count-1].GetComponent<Customer>();
        customer.GoToTargetPosition(customerPosition.position);
        isCustomerComing = true;
        customer.IsCustomerGoingToGrocery = true;
        //Customer dükkandan çýkarken isCustomerComing false olacak
    }

    IEnumerator SendDelayedCustomerToGrocery(){
        while (isCustomerComing){
            SendCustomerToGrocery();
            yield return new WaitForSeconds(10); 
        }
    }

    public void DestroyCustomer(){
        for (int i = 0; i < customerList.Count; i++){
            Customer customer = customerList[i].GetComponent<Customer>();
            if (!customer.IsCustomerGoingToGrocery){
                Destroy(customer.gameObject);
                break;
            }
        }
    }

    IEnumerator DestroyDelayedCustomer(){
        while (true){
            DestroyCustomer();
            yield return new WaitForSeconds(15); 
        }
    }
}
