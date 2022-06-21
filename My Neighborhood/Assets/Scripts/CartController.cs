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
