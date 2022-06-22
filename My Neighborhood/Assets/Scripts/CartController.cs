using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartController : MonoBehaviour
{
    private float speed;
    private float _rotateSpeed;
    [SerializeField] private Joystick joystick;

    void Start()
    {
        speed = 5f;
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
                    
                    //StoreManager.Instance.ItemList.Add(item.GetComponent<Item>().name,1);
                    
                }
                
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
        
        if(joystick.Vertical > 0)
            transform.position += -transform.forward * joystick.Vertical * speed * Time.deltaTime;
        
    }
    
}
