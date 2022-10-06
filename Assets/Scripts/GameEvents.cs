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

    public event Action onScrapTriggerEnter;

    public void scrapTriggerEnter()
    {
        if (onScrapTriggerEnter != null) onScrapTriggerEnter();
    }
    
    public event Action onGameStart;

    public void gameStart()
    {
        if (onGameStart != null) onGameStart();
    }
}
