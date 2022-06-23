using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartController : MonoBehaviour
{
    private float _speed;
    private float _rotateSpeed;
    [SerializeField] private Joystick joystick;

    void Start()
    {
        _speed = 5f;
        _rotateSpeed = 3f;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Item"))
                    AddItemToCart(hit);

                if (hit.transform.CompareTag("Cashout"))
                    MakePayment();
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && joystick.Direction == Vector2.zero)
        {
            float touchX = Input.GetTouch(0).deltaPosition.x;
            float touchY = Input.GetTouch(0).deltaPosition.y;

            transform.Rotate(Vector3.up * touchX * Time.deltaTime * _rotateSpeed);
            Camera.main.transform.Rotate(Vector3.left * touchY * _rotateSpeed * Time.deltaTime);
        }

        if (joystick.Vertical > 0)
            transform.position += -transform.forward * joystick.Vertical * _speed * Time.deltaTime;
    }

    private void MakePayment()
    {
        if (StoreManager.Instance.ItemList.Count == 0)
            return;

        foreach (KeyValuePair<string, int> keyValuePair in StoreManager.Instance.ItemList)
        {
            int stockValue = 0;
            int itemListValue = keyValuePair.Value;
            foreach (KeyValuePair<string, int> stockKeyValuePair in Grocery.Instance.Stock)
            {
                if (stockKeyValuePair.Key.Equals(keyValuePair.Key))
                {
                    stockValue = stockKeyValuePair.Value;
                    break;
                }
            }

            Grocery.Instance.Stock.Remove(keyValuePair.Key);
            Grocery.Instance.Stock.Add(keyValuePair.Key, stockValue + itemListValue);
        }

        StoreManager.Instance.ItemList.Clear();
    }

    private void AddItemToCart(RaycastHit hit)
    {
        GameObject item = hit.transform.gameObject;

        //Item'ı cartın içine koy ve onun child'ı yap
        //Item'ı cart'a ekle liste olan karta.

        item.transform.position = StoreManager.Instance.Cart.transform.position + Vector3.up * 2f;
        item.GetComponent<Rigidbody>().useGravity = true;
        //item.transform.SetParent(StoreManager.Instance.Cart.transform);

        //TODO: cart hareket ettikçe item'lar içinden düşüyor. Bunu önlemek lazım.

        string itemName;

        if (item.name.Contains("("))
        {
            itemName = item.name.Substring(0, item.name.IndexOf("(") - 1);
        }
        else
        {
            itemName = item.name;
        }

        //TODO: eğer listede key yoksa yeni ekle
        //TODO: eğer varsa value'sunu 1 arttır
        if (!StoreManager.Instance.ItemList.ContainsKey(itemName))
        {
            StoreManager.Instance.ItemList.Add(itemName, 1);
        }
        else
        {
            foreach (KeyValuePair<string, int> keyValuePair in StoreManager.Instance.ItemList)
            {
                if (keyValuePair.Key.Equals(itemName))
                {
                    int value = keyValuePair.Value;
                    StoreManager.Instance.ItemList.Remove(itemName);
                    StoreManager.Instance.ItemList.Add(itemName, value + 1);
                    break;
                }
            }
        }
    }
}