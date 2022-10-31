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
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onScrapTriggerEnter += updateScore;
        GameEvents.current.onBatteryChange += updateBattery;
    }

    public void updateScore()
    {
        
    }

    public void updateBattery()
    {
        Debug.Log(stats.percentageRescource/100f);
        battery.fillAmount = stats.percentageRescource/100f;
    }
}
