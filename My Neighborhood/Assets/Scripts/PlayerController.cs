using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float speed;
    [SerializeField]private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {

        //TODO: joystick ile y ekseninde döndürme yapılacak.
        //TODO: transform.forward yönünde speed hızında translate edilecek.

    }
}
