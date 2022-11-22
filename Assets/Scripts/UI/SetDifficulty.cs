using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _difficulty;
    [SerializeField] private Slider _slider;
    [SerializeField] private DifficultySettings diff;
    
    public void updateDifficulty()
    {
        
        switch ((int)_slider.value)
        {
            case (int) DifficultyEnum.EASY:
                _difficulty.SetText("Easy");
                diff.currentDifficulty = DifficultyEnum.EASY;
                break;
            case (int) DifficultyEnum.MEDIUM:
                _difficulty.SetText("Medium");
                diff.currentDifficulty = DifficultyEnum.MEDIUM;
                break;
            case (int) DifficultyEnum.HARD:
                _difficulty.SetText("Hard");
                diff.currentDifficulty = DifficultyEnum.HARD;
                break;
        }
    }
}
