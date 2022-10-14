using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class BatteryResource : MonoBehaviour
{
    [SerializeField] private playerStats stats;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(resource());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator resource()
    {
        while (stats.percentageRescource > 0)
        {
            yield return new WaitForSeconds(stats.waitTime); 
            stats.percentageRescource -= stats.decayRate;
            GameEvents.current.batteryDecay();
        }
        
    }
}
