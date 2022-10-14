using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHUD : MonoBehaviour
{
    [SerializeField] private playerStats stats;
    [SerializeField] private TextMeshProUGUI scrap;
    [SerializeField] private TextMeshProUGUI battery;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onScrapTriggerEnter += updateScore;
        GameEvents.current.onBatteryDecay += updateBattery;
        battery.SetText(stats.percentageRescource.ToString());
    }

    public void updateScore()
    {
        scrap.SetText("" + stats.scrap);
    }

    public void updateBattery()
    {
        battery.SetText(stats.percentageRescource.ToString());
    }
}
