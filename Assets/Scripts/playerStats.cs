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
    private bool readyToJump;

    [Header("Ground Check")] 
    public float playerHight;
    public LayerMask LayerMask;
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
    [Header("Score")]
    public int scrap = 0;
    
    [Space(30)]
    [Header("Settings")] 
    [Range(1f,10f)]
    public float mouseSensitivity = 3f;

    public void resetStats()
    {
        percentageRescource = 100;
        currentHealth = 100;
        scrap = 0;
    }

}
