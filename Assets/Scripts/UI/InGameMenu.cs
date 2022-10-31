using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _mouseSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;
    [SerializeField] private playerStats _stats;
    // Start is called before the first frame update
    void Start()
    {
        float value;
        _audioMixer.GetFloat("musicVolume", out value);
        _musicSlider.value = value;

        _audioMixer.GetFloat("sfxVolume", out value);
        _SFXSlider.value = value;

        _mouseSlider.value = _stats.mouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        _audioMixer.SetFloat("musicVolume", _musicSlider.value);
        _audioMixer.SetFloat("sfxVolume", _SFXSlider.value);
        _stats.mouseSensitivity = _mouseSlider.value;
    }
    
    public void openSettings()
    {
        _animator.SetBool("settings", true);
    }

    public void closeSettings()
    {
        _animator.SetBool("settings", false);
    }

    public void unpauseGame()
    {
        GameEvents.current.GameUnpaused();
    }
    
    public void quitGame()
    {
        GameEvents.current.gameQuit();
    }
}
