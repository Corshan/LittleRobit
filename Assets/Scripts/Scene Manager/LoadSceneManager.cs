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
    [SerializeField] private playerStats stats;
    private bool _gamePaused;

    private void Awake()
    {
        current = this;
        if (!Testing)
        {
            SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN_MENU, LoadSceneMode.Additive);
            currentSceneIndex = (int)SceneIndexes.MAIN_MENU;
        }

        _gamePaused = false;
        GameEvents.current.onGameStart += startGame;
        GameEvents.current.onLevelChange += loadScene;
        GameEvents.current.onGameQuit += quitGame;
        GameEvents.current.onLevelReset += resetLevel;
        GameEvents.current.onGamePaused += pauseGame;
        GameEvents.current.onGameUnpaused += unpauseGame;
    }
    
    public void startGame()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        SceneManager.LoadSceneAsync((int)SceneIndexes.LEVEL_GEN, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)SceneIndexes.HUD, LoadSceneMode.Additive);
        stats.resetStats();
        currentSceneIndex = (int) SceneIndexes.LEVEL_GEN;
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)SceneIndexes.LEVEL_GEN));

    }

    public void loadScene(int level)
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        //if (Testing) SceneManager.LoadSceneAsync((int)SceneIndexes.MANAGER);
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        currentSceneIndex = level;
    }

    public void resetLevel()
    {
        SceneManager.UnloadSceneAsync(currentSceneIndex);
        stats.resetStats();
        SceneManager.LoadSceneAsync(currentSceneIndex, LoadSceneMode.Additive);
    }

    public void pauseGame()
    {
        if (!_gamePaused)
        {
            Time.timeScale = 0;
            SceneManager.LoadSceneAsync((int)SceneIndexes.PAUSE_MENU, LoadSceneMode.Additive);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _gamePaused = true;
        }
        else
        {
            unpauseGame();
        }
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync((int)SceneIndexes.PAUSE_MENU);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _gamePaused = false;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
