using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager current;

    private void Awake()
    {
        current = this;
        SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
    }

    public event Action onStartGame;
    public static void startGame()
    {
        SceneManager.LoadSceneAsync((int)SceneIndexes.SCRAP_LEVEL, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)SceneIndexes.HUD, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MAIN_MENU);
    }

    public void loadScene(String sceneName)
    {
        
    }
}
