using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour{
    private Slider slider;
    private float fillSpeed = 0.5f;
    private float targetProgress = 0;
    //private int buildingAmount = 0;
    private Text amountPlaceholder;
    [SerializeField] private Street street;
    
    void Awake(){
        slider = gameObject.GetComponent<Slider>();
    }

    void Start(){

        AddProgress(street.CalculateOwnRate());
        amountPlaceholder = transform.GetChild(3).GetComponent<Text>();
        
        
    }
    
    void Update(){
        if (slider.value < targetProgress)
            slider.value += fillSpeed * Time.deltaTime;

        UpdateUI();
        Debug.Log(street.OwnedBuildings);
    }

    public void AddProgress(float value){
        targetProgress = slider.value + value;
    }

    public void UpdateUI(){
        if(!gameObject.name.StartsWith("Y"))
            amountPlaceholder.text = street.OwnedBuildings + "/3";
        else
            amountPlaceholder.text = street.OwnedBuildings + "/1";
    }
}
