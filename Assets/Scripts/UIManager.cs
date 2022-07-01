using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject infoPanel;
    [SerializeField]private GameObject buildingInfoBox;
    [SerializeField]private GameObject achievementBox;
    [SerializeField] private Text budgetText;

    private GameObject _currentlyObservedBuilding;


    public GameObject InfoPanel => infoPanel;
    public GameObject BuildingInfoBox => buildingInfoBox;

    public GameObject CurrentlyObservedBuilding
    {
        get => _currentlyObservedBuilding;
        set => _currentlyObservedBuilding = value;
    }
    
    private UIManager(){}
    
    void Start()
    {
        Instance = this;
    }

    void Update()
    {
        budgetText.text = Player.Instance.Budget.ToString();
    }

    public void OnPurchaseButtonClicked()
    {

        GameObject purchasingElements = buildingInfoBox.transform.GetChild(3).gameObject;
        
        if(Player.Instance.Purchase(CurrentlyObservedBuilding.GetComponent<Building>()))
            purchasingElements.SetActive(false);
        
    }

    public void OnEnterButtonClicked()
    {
        
        //TODO: ilgili scene' yükle
        Debug.Log("sa");
        SceneManager.LoadScene(CurrentlyObservedBuilding.name);

    }

    public void OnCrossButtonClicked()
    {
        
        infoPanel.SetActive(false);
        _currentlyObservedBuilding = null;

    }
}
