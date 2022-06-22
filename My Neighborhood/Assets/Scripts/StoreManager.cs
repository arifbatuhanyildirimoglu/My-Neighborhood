using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public static StoreManager Instance;
    
    [SerializeField] private GameObject cart;
    private Dictionary<string, int> itemList;


    private StoreManager(){}
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        itemList = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Cart => cart;
    public Dictionary<string, int> ItemList => itemList;
}
