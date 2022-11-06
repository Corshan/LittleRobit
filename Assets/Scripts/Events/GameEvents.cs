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

    public event Action onHealthPackTriggerEnter;

    public void healthPackTriggerEnter()
    {
        if (onHealthPackTriggerEnter != null) onHealthPackTriggerEnter();
    }
    
    public event Action onBatteryChange;

    public void batteryChange()
    {
        if (onBatteryChange != null) onBatteryChange();
    }

    public event Action onHealthChange;

    public void healthChange()
    {
        if (onHealthChange != null) onHealthChange();
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

    public event Action onGamePaused;

    public void GamePaused()
    {
        if (onGamePaused != null) onGamePaused();
    }

    public event Action onGameUnpaused;

    public void GameUnpaused()
    {
        if (onGameUnpaused != null) onGameUnpaused();
    }

}
