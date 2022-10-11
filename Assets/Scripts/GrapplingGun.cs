using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3 grapplePoint;
    private bool grappling = false;
    private SpringJoint joint;
    
    [Header("Layer Mask")]
    [SerializeField] private LayerMask LayerMask;
    
    [Header("Tansforms")]
    [SerializeField] private Transform gunTip;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform player;
    
    [Header("RayCast Settings")]
    [Range(1f,200f)]
    [SerializeField] private float maxGrappleDistance = 100f;

    [Header("Joint Settings")] 
    [Range(0f,1f)]
    [SerializeField] private float minDistance = 0.25f;
    [Range(0f,1f)]
    [SerializeField] private float maxDistance = 0.8f;
    [Range(0f,10f)]
    [SerializeField] private float spring = 4.5f;
    [Range(0f,10f)]
    [SerializeField] private float damper = 7f;
    [Range(0f,10f)]
    [SerializeField] private float massScale = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
    }
    
    private void LateUpdate()
    {
        DrawRope();
    }

    public void OnGrapple(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            StartGrapple();
        }
        else
        {
            StopGrapple();
        }
        
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxGrappleDistance, LayerMask) )
        {
            grappling = true;
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * maxDistance;
            joint.minDistance = distanceFromPoint * minDistance;

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = massScale;
            
            _lineRenderer.positionCount = 2;
        }
    }

    private void DrawRope()
    {
        if (!joint) return;
        _lineRenderer.SetPosition(0,gunTip.position);
        _lineRenderer.SetPosition(1, grapplePoint);
    }

    private void StopGrapple()
    {
        _lineRenderer.positionCount = 0;
        Destroy(joint);
    }
}
