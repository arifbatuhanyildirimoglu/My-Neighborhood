using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;

public class GroceryController : MonoBehaviour
{

    [SerializeField] private GameObject orderBagObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Malzemeye tıklandığında orderBag'e atacak.
        //Stocktan malzemeyi eksiltecek
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Item"))
                    AddItemToOrderBag(hit);

            }
        }
    }

    private void AddItemToOrderBag(RaycastHit hit)
    {

        OrderBag orderBag = orderBagObject.GetComponent<OrderBag>();
        
        //currentOrder'daki keylerin isimleri ile orderBag'teki contentin keyi aynı olmak zorunda
        //o an basılan item'ın ismi alınır Apple (clone) ise apple olarak alınır ve önceki value'suna 1 eklenir

        string name = hit.transform.gameObject.name.Substring(0, hit.transform.gameObject.name.IndexOf("("));
        int value = 0;
        
        Debug.Log(name);
        
        GameObject key = GameObject.Find(name);

        if (!orderBag.Content.ContainsKey(key))
        {
            orderBag.Content.Add(key, 1);
        }
        else
        {
            foreach (KeyValuePair<GameObject, int> keyValuePair in orderBag.Content)
            {

                if (keyValuePair.Key == key)
                {
                    value = keyValuePair.Value;
                    break;
                }
                
            }

            orderBag.Content.Remove(key);
            orderBag.Content.Add(key, value + 1);
        }

        Destroy(hit.transform.gameObject);
    }
}
