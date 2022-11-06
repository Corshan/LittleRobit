using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats")]
public class playerStats : ScriptableObject
{
    [Header("Movement")] 
    [Range(0f,20f)]
    public float moveSpeed;
    [Range(0f,20f)]
    public float groundDrag;
    [Range(0f,20f)]
    public float jumpForce;
    [Range(0f,20f)]
    public float jumpCoolDown;
    [Range(0f,20f)]
    public float airMultiplier;

    [Header("Ground Check")] 
    public float playerHight;
    public LayerMask groundLayerMask;
    [Space(30)]
    [Header("-----------Grapple Hook------------")]
    [Header("RayCast Settings")]
    [Range(1f,200f)]
    public float maxGrappleDistance = 100f;

    [Header("Joint Settings")] 
    [Range(0f,1f)]
     public float minDistance = 0.25f;
    [Range(0f,1f)]
     public float maxDistance = 0.8f;
    [Range(0f,10f)]
    public float spring = 4.5f;
    [Range(0f,10f)]
     public float damper = 7f;
    [Range(0f,10f)]
     public float massScale = 4.5f;
    [Header("Layer Mask")]
     public LayerMask grappleHookLayerMask;
    [Header("---------------------------------")]
    [Space(30)]
    
    [Header("Health")]
    public int currentHealth = 100;
    public int maxHealth = 100;

    [Space(30)]
    [Header("Battery")]
    public int percentageRescource = 100;
    [Range(0.1f,10f)]
    public float decayRate = 3f;
    [Range(0.1f,10f)]
    public float chargeRate = 3f;
    [Range(1,10)]
    public int decayAmount = 1;
    [Range(1, 10)] 
    public int chargeAmount = 1;
    
    [Space(30)]
    [Header("Inventory")]
    public int scrap = 0;
    public int healthPacks = 0;
    
    [Space(30)]
    [Header("--------------Settings---------------")] 
    [Range(1f,10f)]
    public float mouseSensitivity = 3f;

    public void resetStats()
    {
        percentageRescource = 100;
        currentHealth = 100;
        scrap = 0;
    }

}
