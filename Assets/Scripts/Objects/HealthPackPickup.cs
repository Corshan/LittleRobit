using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackPickup : MonoBehaviour
{
    [SerializeField] private playerStats _stats;
    private void OnTriggerEnter(Collider other)
    {
        _stats.healthPacks++;
        GameEvents.current.healthPackTriggerEnter();
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GameObject.Destroy(gameObject, 2f);
    }
}
