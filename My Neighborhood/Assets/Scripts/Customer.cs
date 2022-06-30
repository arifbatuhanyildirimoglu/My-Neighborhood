using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class Customer : MonoBehaviour
{

    private Vector3[] _path;
    private Animator _animator;
    private GameObject _apple;
    private GameObject _avocado;
    private GameObject _beer;
    private GameObject _cannedFood;
    private GameObject _carrot;
    private GameObject _cola;
    private GameObject _egg;
    
    // Start is called before the first frame update
    void Start()
    {
        _path = new Vector3[4];
        _animator = GetComponent<Animator>();
        
        _path[0] = new Vector3(-8, 0.5f, -2.5f);
        _path[1] = new Vector3(-15.3f,0.5f,-2.5f);
        _path[2] = new Vector3(-15.32f,0.5f,-11.62f);
        _path[3] = new Vector3(-18.32f,0.5f,-11.62f);
        
        _apple = GameObject.Find("Apple");
        _avocado = GameObject.Find("Avocado");
        _beer = GameObject.Find("Beer");
        _cannedFood = GameObject.Find("Canned Food");
        _carrot = GameObject.Find("Carrot");
        _cola = GameObject.Find("Cola");
        _egg = GameObject.Find("Egg");
        
        Walk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Walk()
    {
        transform.DOPath(_path, 10f)
            .OnWaypointChange(Look)
            .OnComplete(GiveOrder);
    }

    void Look(int index)
    {
        transform.LookAt(_path[index]);
    }

    void GiveOrder()
    {
        GameObject lookAt = GameObject.Find("LookAt");
        
        transform.LookAt(lookAt.transform.position);
        _animator.SetTrigger("giveOrder");

        Order order = new Order();
        order.Customer = this;
        CreateOrderContent(order);

        GroceryManager.Instance.CurrentOrder = order;
    }

    void CreateOrderContent(Order order)
    {
        List<GameObject> items = new List<GameObject>();
        items.Add(_apple);
        items.Add(_avocado);
        items.Add(_beer);
        items.Add(_cannedFood);
        items.Add(_carrot);
        items.Add(_cola);                       
        items.Add(_egg);

        int randomItemCount = Random.Range(1, 8);

        for (int i = 0; i < randomItemCount; i++)
        {

            int randomIndex = Random.Range(0,items.Count);
            int randomAmount = Random.Range(1, 11);
            
            GameObject item = items[randomIndex];
            items.RemoveAt(randomIndex);

            order.Content.Add(item, randomAmount);
        }

    }
}
