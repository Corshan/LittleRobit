using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")] 
    [Range(0f,20f)]
    [SerializeField] private float moveSpeed;
    [Range(0f,20f)]
    [SerializeField] private float groundDrag;
    [Range(0f,20f)]
    [SerializeField] private float jumpForce;
    [Range(0f,20f)]
    [SerializeField] private float jumpCoolDown;
    [Range(0f,20f)]
    [SerializeField] private float airMultiplier;
    private bool readyToJump;

    [Header("Ground Check")] 
    [SerializeField] private float playerHight;
    [SerializeField] private LayerMask LayerMask;
    private bool grounded;
    

    [SerializeField] private Transform orientation;
    [SerializeField] private Rigidbody Rigidbody;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    private void Start()
    {
        readyToJump = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHight * 0.5f + 0.2f, LayerMask);
        
        speedControl();
        
        if (grounded) Rigidbody.drag = groundDrag;
        else Rigidbody.drag = 0;
    }

    private void FixedUpdate()
    {
        move();
    }

    public void onMove(InputAction.CallbackContext callbackContext)
    {
        Vector2 vector = callbackContext.ReadValue<Vector2>();
        horizontalInput = vector.x;
        verticalInput = vector.y;
    }

    public void onJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.ReadValueAsButton() && readyToJump && grounded)
        {
            readyToJump = false;
            
            jump();
            
            Invoke(nameof(resetJump), jumpCoolDown);
        }
    }

    private void move()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
        {
            Rigidbody.AddForce(moveSpeed * 10f * moveDirection.normalized, ForceMode.Force);
        }
       else if (!grounded)
        {
            Rigidbody.AddForce(moveSpeed * 10f * airMultiplier * moveDirection.normalized, ForceMode.Force);
        }
       
       
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            Rigidbody.velocity = new Vector3(limitedVel.x, Rigidbody.velocity.y, limitedVel.z);
        }
    }

    private void jump()
    {
        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0f, Rigidbody.velocity.z);
        
        Rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void resetJump()
    {
        readyToJump = true;
    }
}
