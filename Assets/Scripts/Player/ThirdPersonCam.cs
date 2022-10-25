using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private Transform orientaion;
    
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform lookAt;

    [Header("Settings")] 
    [SerializeField] private playerStats stats;
    
    private float horizontalInput;
    private float verticalInput;

    private CinemachineFreeLook camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camera = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientaion.forward = viewDir.normalized;

        Vector3 inputDir = orientaion.forward * verticalInput + orientaion.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * stats.mouseSensitivity);
    */
        Vector3 dir = lookAt.position - new Vector3(transform.position.x, lookAt.position.y, transform.position.z);
        orientaion.forward = dir;

        playerObj.forward = dir;

        camera.m_XAxis.m_MaxSpeed = stats.mouseSensitivity * 100;
        camera.m_YAxis.m_MaxSpeed = stats.mouseSensitivity;
    }
    
    public void onMove(InputAction.CallbackContext callbackContext)
    {
        Vector2 vector = callbackContext.ReadValue<Vector2>();
        horizontalInput = vector.x;
        verticalInput = vector.y;
    }
}
