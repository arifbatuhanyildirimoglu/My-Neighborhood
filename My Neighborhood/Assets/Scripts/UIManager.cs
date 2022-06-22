using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject infoPanel;
    [SerializeField]private GameObject buildingInfoBox;
    [SerializeField] private Text budgetText;
    [SerializeField] private GameObject stockListDeneme;

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
        
        SceneManager.LoadScene(CurrentlyObservedBuilding.name);

    }

    public void OnCrossButtonClicked()
    {
        
        infoPanel.SetActive(false);
        _currentlyObservedBuilding = null;

    }

    
    //Deneme amaçlı
    public void OnStockButtonClicked()
    {
        Dictionary<string,int> stock = Grocery.Instance.Stock;

        stockListDeneme.SetActive(true);
        
        for (int i = 0; i < stockListDeneme.transform.childCount; i++)
        {
            stockListDeneme.transform.GetChild(i).GetComponent<Text>().text = stock.Keys.ElementAt(i) + ": " + stock.Values.ElementAt(i);
        }
    }
}
