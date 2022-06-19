using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed;
    private Rigidbody rigidbody;
    private Animator animator;
    [SerializeField] private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector3 target = Camera.main.WorldToScreenPoint(touch.position);
            
            Debug.DrawRay(Camera.main.transform.position,target, Color.red);
            
        }
        */

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.transform.position, Color.red);

                if (hit.transform.CompareTag("Building"))
                {
                    GameObject buildingInfoBox = UIManager.Instance.BuildingInfoBox;
                    GameObject building = hit.transform.gameObject;
                    GameObject purchasingElements = buildingInfoBox.transform.GetChild(3).gameObject;
                    
                    buildingInfoBox.SetActive(true);

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

                    UIManager.Instance.CurrentlyObservedBuilding = building;

                }
            }
        }
    }

    void FixedUpdate()
    {
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