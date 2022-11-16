using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyStats")]
public class EnemyStats : ScriptableObject
{
    [Range(1f,10f)]
    public float walkingSpeed = 7f;
    [Range(1f,10f)]
    public float runningSpped = 7f;
    [Range(1f,5f)]
    public float attackDistance = 1f;
}
