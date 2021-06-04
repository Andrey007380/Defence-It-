﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{

    public static bool Paude = false;
    public static bool SettingsMenu = false;
    public GameObject PauuseMenuUI;
    public GameObject DeatScreenAndAds;
    public GameObject Settings;
    public AudioMixer audioMixer;
    public Image VolumeImage;
    public Slider VolumeSlider;
    public Sprite OffSound;
    public Sprite OnSound;
    public FixedJoystick rotationJoystic;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        if (VolumeSlider.value > 0)
        {
            VolumeImage.sprite = OnSound;
        }
        else
        {
            VolumeImage.sprite = OffSound;
        }
    }

    public static PauseMenu Instance { get;  set;}

    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
       
        VolumeImage.sprite = OffSound;
        Image ButtonImage = VolumeImage.GetComponent<Image>();
        PauuseMenuUI.SetActive(false);
        Settings.SetActive(false);
    }


    public void Setting()
    {
        if (SettingsMenu)
        {
            PauuseMenuUI.SetActive(!PauuseMenuUI.active);
            Settings.SetActive(!Settings.active);
            SettingsMenu = false;
        }
        else
        {
            PauuseMenuUI.SetActive(!PauuseMenuUI.active);
            Settings.SetActive(!Settings.active);
            SettingsMenu = true;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

   public void Resume()
    {
        Time.timeScale = 1;
        PauuseMenuUI.SetActive(!PauuseMenuUI.active);
        Paude = false;
    }
    void Paused()
    {
        PauuseMenuUI.SetActive(!PauuseMenuUI.active);
        Paude = true;
        Time.timeScale = 0;
    }
    public void MenuCaller()
    {
            if (Paude)
            {
            Resume(); 
        }
            else
            {  
            Paused(); 
        }
    }
    public void RotationChooser()
    {
        rotationJoystic.gameObject.SetActive(!rotationJoystic.gameObject.active);
    }
}
