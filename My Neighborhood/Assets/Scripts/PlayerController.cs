using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private Rigidbody rigidbody;
    private Animator animator;
    [SerializeField] private Joystick joystick;

    void Start()
    {
        speed = 5f;
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        
    }

    void Update()
    {
        if(joystick == null && !SceneManager.GetActiveScene().name.Equals("Grocery"))
            joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<Joystick>();
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            GameObject infoPanel = UIManager.Instance.InfoPanel;
            GameObject buildingInfoBox = UIManager.Instance.BuildingInfoBox;

            if (Physics.Raycast(ray, out hit) && UIManager.Instance.CurrentlyObservedBuilding == null)
            {

                if (hit.transform.CompareTag("Building") || hit.transform.CompareTag("Grocery"))
                {
                    GameObject building = hit.transform.gameObject;
                    GameObject purchasingElements = buildingInfoBox.transform.GetChild(3).gameObject;
                    GameObject enterButton = buildingInfoBox.transform.GetChild(4).gameObject;

                    infoPanel.SetActive(true);

                    buildingInfoBox.transform.GetChild(1).GetComponent<Text>().text =
                        building.GetComponent<Building>().Name;

                    if (!building.GetComponent<Building>().IsOwned)
                    {
                        purchasingElements.SetActive(true);
                        purchasingElements.transform.GetChild(1).GetComponent<Text>().text = building
                            .GetComponent<Building>().PurchasePrice + "$";
                    }
                    else
                    {
                        purchasingElements.SetActive(false);
                    }


                    string buildingName = building.gameObject.name;
                    if (building.CompareTag("Grocery") || buildingName.Equals("Store"))
                    {
                        enterButton.SetActive(true);
                    }
                    else
                    {
                        enterButton.SetActive(false);
                    }

                    UIManager.Instance.CurrentlyObservedBuilding = building;
                }
                else
                {
                    infoPanel.SetActive(false);
                    UIManager.Instance.CurrentlyObservedBuilding = null;
                }
            }
        }

        /*
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            GameObject infoPanel = UIManager.Instance.InfoPanel;
            GameObject buildingInfoBox = UIManager.Instance.BuildingInfoBox;

            if (Physics.Raycast(ray, out hit) && UIManager.Instance.CurrentlyObservedBuilding == null)
            {
                Debug.DrawLine(ray.origin, hit.transform.position, Color.red);

                if (hit.transform.CompareTag("Building"))
                {
                    
                    GameObject building = hit.transform.gameObject;
                    GameObject purchasingElements = buildingInfoBox.transform.GetChild(3).gameObject;
                    GameObject enterButton = buildingInfoBox.transform.GetChild(4).gameObject;

                    infoPanel.SetActive(true);

                    buildingInfoBox.transform.GetChild(1).GetComponent<Text>().text =
                        building.GetComponent<Building>().Name;

                    if (!building.GetComponent<Building>().IsOwned)
                    {
                        purchasingElements.SetActive(true);
                        purchasingElements.transform.GetChild(1).GetComponent<Text>().text = building
                            .GetComponent<Building>().PurchasePrice + "$";
                    }
                    else
                    {
                        purchasingElements.SetActive(false);
                    }

                    
                    string buildingName = building.gameObject.name;
                    if (buildingName.Equals("Grocery") || buildingName.Equals("Store"))
                    {
                        enterButton.SetActive(true);
                    }
                    else
                    {
                        enterButton.SetActive(false);
                    }
                    
                    UIManager.Instance.CurrentlyObservedBuilding = building;

                }
                else
                {
                    infoPanel.SetActive(false);
                    UIManager.Instance.CurrentlyObservedBuilding = null;
                }
            }
            
            */
    }

    void FixedUpdate()
    {
        if(joystick == null)
            return;
        
        rigidbody.velocity = new Vector3(speed * joystick.Horizontal, rigidbody.velocity.y, speed * joystick.Vertical);

        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}