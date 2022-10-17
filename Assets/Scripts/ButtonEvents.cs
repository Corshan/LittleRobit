using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public void startGame()
    {
        GameEvents.current.gameStart();
    }

    public void quitGame()
    {
        GameEvents.current.gameQuit();
    }
}
