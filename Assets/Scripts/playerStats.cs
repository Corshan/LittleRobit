using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerStats")]
public class playerStats : ScriptableObject
{
    [Header("Health Settings")]
    public int health = 100;

    [Header("Battery Settings")]
    public int percentageRescource = 100;
    [Range(0.1f,10f)]
    public float decayRate = 3f;
    [Range(0.1f,10f)]
    public float chargeRate = 3f;
    [Range(1,10)]
    public int decayAmount = 1;
    [Range(1, 10)] 
    public int chargeAmount = 1;
    
    [Header("Score")]
    public int scrap = 0;

}
