using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform orientaion;
    [Range(0f, 10f)]
    [SerializeField] private float mouseSensitivity = 1f;
    private float mouseX;
    private float mouseY;

    private float rotationX;
    private float rotationY;
    
    private Vector2 vector2;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }

    public void onLook(InputAction.CallbackContext callbackContext)
    {
        vector2 = callbackContext.ReadValue<Vector2>();
    }

    private void Look()
    {
        mouseX = vector2.x * Time.deltaTime * mouseSensitivity;
        mouseY = vector2.y * Time.deltaTime * mouseSensitivity;

        rotationX -= mouseY;
        rotationY += mouseX;
        rotationX = Math.Clamp(rotationX, -90f, 90f);
        
        transform.rotation = Quaternion.Euler(rotationX, rotationY,0);
        orientaion.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
