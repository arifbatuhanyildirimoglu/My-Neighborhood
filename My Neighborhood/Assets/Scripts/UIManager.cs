using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject infoPanel;
    [SerializeField]private GameObject buildingInfoBox;
    [SerializeField] private Text budgetText;
    [SerializeField] private GameObject stockList;

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
        //DontDestroyOnLoad(this);
        Instance = this;
        //infoPanel = GameObject.FindGameObjectWithTag("Info Panel");
        //buildingInfoBox = GameObject.FindGameObjectWithTag("Building Info Box");
        //budgetText = GameObject.FindGameObjectWithTag("Budget Text").GetComponent<Text>();
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
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        playerObject.GetComponent<PlayerController>().enabled = false;
        playerObject.transform.GetChild(0).gameObject.SetActive(false);

        if (_currentlyObservedBuilding.name.Contains("Clone"))
            _currentlyObservedBuilding.name = "Grocery";
        
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
        stockList.SetActive(true);
    }

    public void OnExitButtonClicked()
    {

        SceneManager.LoadScene("SampleScene");

    }

    public void OnAppleImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.AppleCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.AppleCameraPosition.transform.rotation, 1f);
        
        /*
        Camera.main.transform.position = GroceryManager.Instance.AppleCameraPosition.transform.position;
        Camera.main.transform.rotation = GroceryManager.Instance.AppleCameraPosition.transform.rotation;
        */
    }

    public void OnAvocadoImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.AvocadoCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.AvocadoCameraPosition.transform.rotation, 1f);
    }

    public void OnBeerImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.BeerCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.BeerCameraPosition.transform.rotation, 1f);
    }

    public void OnCannedFoodImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.CannedFoodCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.CannedFoodCameraPosition.transform.rotation, 1f);
    }

    public void OnCarrotImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.CarrotCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.CarrotCameraPosition.transform.rotation, 1f);
    }

    public void OnColaImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.ColaCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.ColaCameraPosition.transform.rotation, 1f);
    }

    public void OnEggImageClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.EggCameraPosition.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.EggCameraPosition.transform.rotation, 1f);
    }
}
