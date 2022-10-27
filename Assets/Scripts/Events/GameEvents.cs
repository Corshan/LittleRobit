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
    
    public event Action onBatteryChange;

    public void batteryChange()
    {
        if (onBatteryChange != null) onBatteryChange();
    }
    
    #endregion

    #region LevelChange
    
    public event Action onGameStart;

    public void gameStart()
    {
        if (onGameStart != null) onGameStart();
    }

    public event Action onGameQuit;

    public void gameQuit()
    {
        if (onGameQuit != null) onGameQuit();
    }

    public event Action<int> onLevelChange;

    public void levelChange(int level)
    {
        if (onLevelChange != null) onLevelChange(level);
    }

    public event Action onLevelReset;

    public void levelReset()
    {
        if (onLevelReset != null) onLevelReset();
    }

    #endregion

}