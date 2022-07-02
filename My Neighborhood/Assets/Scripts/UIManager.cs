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
    [SerializeField] private GameObject buildingInfoBox;
    [SerializeField] private GameObject stockList;
    [SerializeField] private GameObject orderList;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject achievementsPanel;
    [SerializeField] private GameObject lightningStreet;
    [SerializeField] private GameObject attackStreet;
    [SerializeField] private GameObject youngStreet;

    [SerializeField] private Text budgetText;
    [SerializeField] private Text lightningStreetRateText;
    [SerializeField] private Text attackStreetRateText;
    [SerializeField] private Text youngStreetRateText;
    
    [SerializeField] private Sprite appleImage;
    [SerializeField] private Sprite avocadoImage;
    [SerializeField] private Sprite beerImage;
    [SerializeField] private Sprite cannedFoodImage;
    [SerializeField] private Sprite carrotImage;
    [SerializeField] private Sprite colaImage;
    [SerializeField] private Sprite eggImage;

    [SerializeField] private Slider lightningStreetSlider;
    [SerializeField] private Slider attackStreetSlider;
    [SerializeField] private Slider youngStreetSlider;

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

        if (Player.Instance.Purchase(CurrentlyObservedBuilding.GetComponent<Building>()))
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
        stockList.SetActive(!stockList.activeInHierarchy);

        for (int i = 0; i < Grocery.Instance.Stock.Count; i++)
        {

            stockList.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().text =
                Grocery.Instance.Stock.ElementAt(i).Value.ToString();

        }
        
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

    public void OnOrderButtonClicked()
    {
        
        orderList.SetActive(!orderList.activeInHierarchy);

        GameObject content = orderList.transform.GetChild(0).gameObject;
        GameObject infoText = content.transform.GetChild(content.transform.childCount - 2).gameObject;

        if (GroceryManager.Instance.CurrentOrder == null)
        {
            infoText.SetActive(true);
        }
        else
        {
            infoText.SetActive(false);
            
            int itemCount = GroceryManager.Instance.CurrentOrder.Content.Count;
            
            for (int i = 0; i < itemCount; i++)
            {
                GameObject image = content.transform.GetChild(i).gameObject;
                Text amountText = image.transform.GetChild(0).gameObject.GetComponent<Text>();
                Text orderPriceText = content.transform.GetChild(content.transform.childCount - 1).gameObject
                    .GetComponent<Text>();
                string name = GroceryManager.Instance.CurrentOrder.Content.ElementAt(i).Key.name;
                Sprite desiredImage = null;

                switch (name)
                {
               
                    case "Apple":
                        desiredImage = appleImage;
                        break;
                    case "Avocado":
                        desiredImage = avocadoImage;
                        break;
                    case "Beer":
                        desiredImage = beerImage;
                        break;
                    case "Canned Food":
                        desiredImage = cannedFoodImage;
                        break;
                    case "Carrot":
                        desiredImage = carrotImage;
                        break;
                    case "Cola":
                        desiredImage = colaImage;
                        break;
                    case "Egg":
                        desiredImage = eggImage;
                        break;
                
                }
            
                image.SetActive(true);
                image.GetComponent<Image>().sprite = desiredImage;
                amountText.text = GroceryManager.Instance.CurrentOrder.Content.ElementAt(i).Value.ToString();
                orderPriceText.gameObject.SetActive(true);
                orderPriceText.text = GroceryManager.Instance.CurrentOrder.Price.ToString();
                GameObject giveOrderButton = content.transform.GetChild(content.transform.childCount - 3).gameObject;
                giveOrderButton.SetActive(true);
            }
            
        }
        
    }

    public void OnPauseButtonClicked()
    {
        GameManager.Instance.CurrentState = GameState.Pause;
        pausePanel.SetActive(true);
        Time.timeScale = 0;

    }

    public void OnAchievementsButtonClicked()
    {
        
        //TODO: Achievements panelini göster
        //TODO: pause panelini kapat.
        pausePanel.SetActive(false);
        achievementsPanel.SetActive(true);
        //TODO: sliderlar ve rate textler update edilecek.
        lightningStreetSlider.value = lightningStreet.gameObject.GetComponent<Street>().CalculateOwnRate() / 100;
        lightningStreetRateText.text = lightningStreet.gameObject.GetComponent<Street>().CalculateOwnRate() + "%";
        
        attackStreetSlider.value = attackStreet.gameObject.GetComponent<Street>().CalculateOwnRate() / 100;
        attackStreetRateText.text = attackStreet.gameObject.GetComponent<Street>().CalculateOwnRate() + "%";

        youngStreetSlider.value = youngStreet.gameObject.GetComponent<Street>().CalculateOwnRate() / 100;
        youngStreetRateText.text = youngStreet.gameObject.GetComponent<Street>().CalculateOwnRate() + "%";

    }

    public void OnContinueButtonClicked()
    {
        GameManager.Instance.CurrentState = GameState.Gameplay;
        pausePanel.SetActive(false);
        Time.timeScale = 1;

    }

    public void OnGoBackButtonClicked()
    {
        achievementsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void OnCashoutButtonClicked()
    {
        Camera mainCamera = Camera.main;

        mainCamera.transform.DOMove(GroceryManager.Instance.LookAt.transform.position, 1f);
        mainCamera.transform.DORotateQuaternion(GroceryManager.Instance.LookAt.transform.rotation, 1f);
    }
}
