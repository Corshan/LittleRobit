using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrapplingGun : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Vector3 grapplePoint;
    private SpringJoint joint;
    
    private LayerMask LayerMask;
    
    [Header("Tansforms")]
    [SerializeField] private Transform gunTip;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform orientaion;
    [SerializeField] private Transform player;
    [SerializeField] private Transform ray;
    [SerializeField] private playerStats _stats;
    [SerializeField] private Animator _animator;
    
    
    
    private float maxGrappleDistance = 100f;

    private float minDistance = 0.25f;
    
    private float maxDistance = 0.8f;
    
    private float spring = 4.5f;
    
    private float damper = 7f;
    
    private float massScale = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        _lineRenderer = GetComponent<LineRenderer>();
        LayerMask = _stats.grappleHookLayerMask;
        maxGrappleDistance = _stats.maxGrappleDistance;
        minDistance = _stats.minDistance;
        maxDistance = _stats.maxDistance;
        spring = _stats.spring;
        damper = _stats.damper;
        massScale = _stats.massScale;

    }
    
    private void LateUpdate()
    {
        DrawRope();
        //Debug.DrawRay(ray.position, camera.forward, Color.black);
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
        
        if (Physics.Raycast(ray.position, camera.forward, out hit, maxGrappleDistance, LayerMask) )
        {
            _animator.SetBool("Walk_Anim", false);
            _animator.SetBool("Roll_Anim" , true);
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
        _animator.SetBool("Roll_Anim", false);
    }
}
