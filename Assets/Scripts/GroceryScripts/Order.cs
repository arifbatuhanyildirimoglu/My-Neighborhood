using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    [SerializeField] private Item[] items;
    private Dictionary<Item, int> orderList = new Dictionary<Item, int>();
    private List<int> numberList = new List<int> { 0, 1, 2, 3, 4, 5, 6 };
    private int randomNumber;
    private int index = 7;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //7 urun 6 farkli order olacak

    public void CreateOrder()
    {
        for(int i=0; i<6; i++)
        {
            int randomNumber = Random.Range(0, 7);
        }
    }

    public void ChooseRandomNumberAndRemoveNumber(int i)
    {

        int random = Random.Range(0, index);
        randomNumber = numberList[random];
        //orderList.Keys. = items[randomNumber];
        numberList.Remove(random);
        index--;
    }
}
