using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryManager : MonoBehaviour
{

    public static GroceryManager Instance;
    
    [SerializeField] private List<GameObject> appleSpawnPositions;
    [SerializeField] private List<GameObject> avocadoSpawnPositions;
    [SerializeField] private List<GameObject> beerSpawnPositions;
    [SerializeField] private List<GameObject> cannedFoodSpawnPositions;
    [SerializeField] private List<GameObject> carrotSpawnPositions;
    [SerializeField] private List<GameObject> colaSpawnPositions;
    [SerializeField] private List<GameObject> eggSpawnPositions;

    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject avocadoPrefab;
    [SerializeField] private GameObject beerPrefab;
    [SerializeField] private GameObject cannedFoodPrefab;
    [SerializeField] private GameObject carrotPrefab;
    [SerializeField] private GameObject colaPrefab;
    [SerializeField] private GameObject eggPrefab;

    [SerializeField] private GameObject appleCameraPosition;
    [SerializeField] private GameObject avocadoCameraPosition;
    [SerializeField] private GameObject beerCameraPosition;
    [SerializeField] private GameObject cannedFoodCameraPosition;
    [SerializeField] private GameObject carrotCameraPosition;
    [SerializeField] private GameObject colaCameraPosition;
    [SerializeField] private GameObject eggCameraPosition;
    
    
    private GroceryManager(){}
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DeployItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DeployItems()
    {

        Dictionary<string, int> stock = Grocery.Instance.Stock;

        foreach (KeyValuePair<string, int> item in stock)
        {
            GameObject prefab;
            List<GameObject> spawnPositions;
            Quaternion quaternion;
            
            switch (item.Key)
            {
                case "Apple":

                    prefab = applePrefab;
                    spawnPositions = appleSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);

                    break;
                case "Avocado":
                    
                    prefab = avocadoPrefab;
                    spawnPositions = avocadoSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
                case "Beer":
                    
                    prefab = beerPrefab;
                    spawnPositions = beerSpawnPositions;
                    quaternion = new Quaternion(0,0,-90,beerPrefab.transform.rotation.w);
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
                case "Canned Food":
                    
                    prefab = cannedFoodPrefab;
                    spawnPositions = cannedFoodSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
                case "Carrot":
                    
                    prefab = carrotPrefab;
                    spawnPositions = carrotSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
                case "Cola":
                    
                    prefab = colaPrefab;
                    spawnPositions = colaSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
                case "Egg":
                    
                    prefab = eggPrefab;
                    spawnPositions = eggSpawnPositions;
                    quaternion = Quaternion.identity;
                    
                    InstantiateItem(prefab, spawnPositions, quaternion, item.Value);
                    
                    break;
            }
            
        }

    }

    public void InstantiateItem(GameObject prefab, List<GameObject> spawnPositions, Quaternion quaternion, int amount)
    {

        for (int i = 0; i < amount; i++)
        {
            GameObject spawnPos = null;
                    
            foreach (GameObject spawnPosition in spawnPositions)
            {
                if (spawnPosition.transform.childCount == 0)
                {
                    spawnPos = spawnPosition;
                    
                    break;
                }
                    
            }

            GameObject item = Instantiate(prefab,spawnPos.transform.position,quaternion); 
            item.transform.SetParent(spawnPos.transform);
        }
        
    }

    public GameObject AppleCameraPosition => appleCameraPosition;

    public GameObject AvocadoCameraPosition => avocadoCameraPosition;

    public GameObject BeerCameraPosition => beerCameraPosition;

    public GameObject CannedFoodCameraPosition => cannedFoodCameraPosition;

    public GameObject CarrotCameraPosition => carrotCameraPosition;

    public GameObject ColaCameraPosition => colaCameraPosition;

    public GameObject EggCameraPosition => eggCameraPosition;
}
