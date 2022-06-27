using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{

    public static StoreManager Instance;
    
    [SerializeField] private GameObject cart;
    [SerializeField] private List<GameObject> cartSlots;
    private Dictionary<string, int> _itemList;


    private StoreManager(){}
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        _itemList = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Cart => cart;
    public Dictionary<string, int> ItemList => _itemList;

    public List<GameObject> CartSlots => cartSlots;
}
