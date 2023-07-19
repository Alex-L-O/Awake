using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    [SerializeField] private GameObject musicCheck, sfxCheck;

    private void Start()
    {
        _sfxSlider.value = AudioManager.Instance.sfxSource.volume;
        _musicSlider.value = AudioManager.Instance.musicSource.volume;
        musicCheck.SetActive(false);
        sfxCheck.SetActive(false);
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        if (musicCheck.activeInHierarchy)
        {
            musicCheck.SetActive(false);
        }
        else
        {
            musicCheck.SetActive(true);
        }
    }

    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        if (sfxCheck.activeInHierarchy)
        {
            sfxCheck.SetActive(false);
        }
        else
        {
            sfxCheck.SetActive(true);
        }
    }

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }
}