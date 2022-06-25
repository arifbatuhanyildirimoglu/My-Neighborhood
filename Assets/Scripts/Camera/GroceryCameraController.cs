using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryCameraController : MonoBehaviour{
    private CameraStates cameraState;
    private Camera camera;
    private float cameraSpeed = 5f;
    private float rotationY;
    [SerializeField] private Joystick joystick;
    [SerializeField]private Transform cashierCameraTransform, interiorCameraTransform;
    public enum CameraStates{
        CashierCamera,
        InteriorCamera,
        ProductCamera,
    }
    
    void Start(){
        cameraState = CameraStates.CashierCamera;
        camera = Camera.main;
    }


    void LateUpdate(){
        if (cameraState == CameraStates.CashierCamera){
            camera.transform.position = cashierCameraTransform.position;
            
            if (joystick.Vertical != 0 || joystick.Horizontal != 0 && camera.transform.rotation.y <= 45 && camera.transform.rotation.y >= -45)
            {
                camera.transform.Rotate(0, joystick.Vertical * cameraSpeed, 0);
            }
        }

        if (cameraState == CameraStates.InteriorCamera){
            camera.transform.position = interiorCameraTransform.position;
        }
    }
}
