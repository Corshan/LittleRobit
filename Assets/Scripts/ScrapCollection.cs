using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapCollection : MonoBehaviour
{
    public playerStats Stats;
    private void OnTriggerEnter(Collider other)
    {
        Stats.scrap++;
        GameEvents.current.scrapTriggerEnter();
        GameObject.Destroy(gameObject);
    }
}
