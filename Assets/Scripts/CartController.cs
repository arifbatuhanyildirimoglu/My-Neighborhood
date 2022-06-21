using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CartController : MonoBehaviour
{
    private float speed;
    private Rigidbody rigidbody;
    [SerializeField] private Joystick joystick;

    void Start()
    {
        speed = 5f;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(speed * joystick.Horizontal, rigidbody.velocity.y, speed * joystick.Vertical);

        if (joystick.Vertical != 0 || joystick.Horizontal != 0)
        {
            transform.rotation = Quaternion.LookRotation(-rigidbody.velocity);
        }
        
    }
}
