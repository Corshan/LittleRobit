using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrappleGun : MonoBehaviour
{
    
    private Vector3 grapplePoint;
    private SpringJoint joint;

    [SerializeField] private LayerMask whatIsGrapplable;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Transform gunTip, camera, player;
    [SerializeField] private float maxDistance = 100f;
    

    private void Awake()
    {
        //lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        
    }

    public void startGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrapplable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    void drawRope()
    {
        //lr.SetPosition(0, gunTip.position);
    }
}
