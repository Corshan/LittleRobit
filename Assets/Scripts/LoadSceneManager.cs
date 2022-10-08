using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager current;
    private int currentSceneIndex;
    [SerializeField] private bool Testing;

    private void Awake()
    {
        current = this;
        if(!Testing) SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
        GameEvents.current.onGameStart += startGame;
        GameEvents.current.onLevelChange += loadScene;
    }
    
    public void startGame()
    {
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU);
        SceneManager.LoadSceneAsync((int)SceneIndexes.SCRAP_LEVEL, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)SceneIndexes.HUD, LoadSceneMode.Additive);
        currentSceneIndex = (int) SceneIndexes.SCRAP_LEVEL;

    }

    public void loadScene(int level)
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        if (Testing) SceneManager.LoadSceneAsync((int)SceneIndexes.MANAGER);
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        currentSceneIndex = level;
    }
}
