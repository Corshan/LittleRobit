using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _difficulty;
    [SerializeField] private Slider _slider;
    
    public void updateDifficulty()
    {
        
        switch ((int)_slider.value)
        {
            case (int) Difficulty.EASY:
                _difficulty.SetText("Easy");
                break;
            case (int) Difficulty.MEDIUM:
                _difficulty.SetText("Medium");
                break;
            case (int) Difficulty.HARD:
                _difficulty.SetText("Hard");
                break;
        }
    }
}
