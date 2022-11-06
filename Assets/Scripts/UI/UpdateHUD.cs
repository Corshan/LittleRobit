using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHUD : MonoBehaviour
{
    [SerializeField] private playerStats stats;
    [SerializeField] private TextMeshProUGUI scrap;
    [SerializeField] private TextMeshProUGUI healthPacks;
    [SerializeField] private Image battery;
    [SerializeField] private Image health;
    [SerializeField] private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onScrapTriggerEnter += updateScrap;
        GameEvents.current.onBatteryChange += updateBattery;
        GameEvents.current.onHealthChange += updateHealth;
        GameEvents.current.onInventoryOpened += openInventory;
        GameEvents.current.onHealthPackTriggerEnter += updateHealthPack;
    }

    public void updateHealthPack()
    {
        healthPacks.SetText(stats.healthPacks.ToString());
    }
    public void updateScrap()
    {
        scrap.SetText(stats.scrap.ToString());
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
    
    public void openInventory()
    {
        scrap.SetText(stats.scrap.ToString());
        healthPacks.SetText(stats.healthPacks.ToString());
        if (_animator.GetBool("open_inv"))
        {
            _animator.SetBool("open_inv", false);
        }
        else
        {
            _animator.SetBool("open_inv", true);
        }
    }
}
