using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BatteryResource : MonoBehaviour
{
    [SerializeField] private playerStats stats;

    private bool charging;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(resource());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Charging Station")) charging = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Charging Station")) charging = false;
    }


    IEnumerator resource()
    {
        while (stats.percentageRescource > 0)
        {
            
            if (charging)
            {
                if (stats.percentageRescource  < 100) stats.percentageRescource += stats.chargeAmount;
                yield return new WaitForSeconds(stats.chargeRate);
            }
            else
            {
                stats.percentageRescource -= stats.decayAmount;
                yield return new WaitForSeconds(stats.decayRate);
            }

            if (stats.percentageRescource > 100) stats.percentageRescource = 100;
            GameEvents.current.batteryChange();
        }
        
    }
}
