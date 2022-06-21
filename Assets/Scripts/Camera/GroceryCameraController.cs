using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryCameraController : MonoBehaviour{
    private CameraStates camerState;
    private Camera camera;
    private float cameraSpeed = 5f;
    private float rotationY;
    [SerializeField] private Joystick joystick;
    [SerializeField]private Transform cashierPositionTransform;
    public enum CameraStates{
        CashierCamera,
        InteriorCamera,
        ProductCamera,
    }
    
    void Start(){
        camerState = CameraStates.CashierCamera;
        camera = Camera.main;
    }


    void LateUpdate(){
        if (camerState == CameraStates.CashierCamera){
            camera.transform.position = cashierPositionTransform.position;
            
            if (joystick.Vertical != 0 || joystick.Horizontal != 0 && camera.transform.rotation.y <= 45 && camera.transform.rotation.y >= -45)
            {
                camera.transform.Rotate(0, joystick.Vertical * cameraSpeed, 0);
            }
        }
    }
}
