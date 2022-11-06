using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHUD : MonoBehaviour
{
    [SerializeField] private playerStats stats;
    [SerializeField] private TextMeshProUGUI scrap;
    [SerializeField] private Image battery;
    [SerializeField] private Image health;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onScrapTriggerEnter += updateScrap;
        GameEvents.current.onBatteryChange += updateBattery;
        GameEvents.current.onHealthChange += updateHealth;
    }

    public void updateScrap()
    {
        
    }

    public void updateBattery()
    {
        //Debug.Log(stats.percentageRescource/100f);
        battery.fillAmount = stats.percentageRescource/100f;
    }

    public void updateHealth()
    {
        float max = stats.maxHealth;
        health.fillAmount = stats.currentHealth / max;
    }
}
