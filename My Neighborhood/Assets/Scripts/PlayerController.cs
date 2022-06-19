using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed;
    private Rigidbody rigidbody;
    private Animator animator;
    [SerializeField]private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        rigidbody = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        rigidbody.velocity = new Vector3(speed * joystick.Horizontal, rigidbody.velocity.y, speed * joystick.Vertical);

        if (joystick.Vertical != 0 || joystick.Horizontal != 0){
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }
    }
}