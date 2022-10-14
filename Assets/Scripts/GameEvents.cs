using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public void Awake()
    {
        current = this;
    }

    #region Gameplay
    
    public event Action onScrapTriggerEnter;

    public void scrapTriggerEnter()
    {
        if (onScrapTriggerEnter != null) onScrapTriggerEnter();
    }
    
    public event Action onBatteryDecay;

    public void batteryDecay()
    {
        if (onBatteryDecay != null) onBatteryDecay();
    }
    
    #endregion

    #region LevelChange
    
    public event Action onGameStart;

    public void gameStart()
    {
        if (onGameStart != null) onGameStart();
    }

    public event Action<int> onLevelChange;

    public void levelChange(int level)
    {
        if (onLevelChange != null) onLevelChange(level);
    }
    
    #endregion
    
}
