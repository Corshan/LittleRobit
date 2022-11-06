using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _mouseSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;
    [SerializeField] private playerStats _stats;

    private void Start()
    {
        float value;
        _audioMixer.GetFloat("musicVolume", out value);
        _musicSlider.value = value;

        _audioMixer.GetFloat("sfxVolume", out value);
        _SFXSlider.value = value;

        _mouseSlider.value = _stats.mouseSensitivity;
    }

    private void Update()
    {
        _audioMixer.SetFloat("musicVolume", _musicSlider.value);
        _audioMixer.SetFloat("sfxVolume", _SFXSlider.value);
        _stats.mouseSensitivity = _mouseSlider.value;
    }

    public void startGame()
    {
        GameEvents.current.levelChange((int)SceneIndexes.INSTRUCTIONS);
    }

    public void quitGame()
    {
        GameEvents.current.gameQuit();
    }

    public void openSettings()
    {
        _animator.SetBool("settings", true);
    }

    public void closeSettings()
    {
        _animator.SetBool("settings", false);
    }
}
