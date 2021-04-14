using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;

public class PauseMenu : MonoBehaviour
{

    public static bool Paude = false;
    public static bool SettingsMenu = false;
    public GameObject PauuseMenuUI;
    public GameObject Settings;
    public AudioMixer audioMixer;
    public Button VolumeButton;
    public Slider VolumeSlider;
    public Sprite OffSound;
    public Sprite OnSound;
    public FixedJoystick rotationJoystic;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
        if (VolumeSlider.value > 0)
        {
            VolumeButton.image.sprite = OffSound;
            VolumeSlider.value = 0;
        }
        else
        {
            VolumeButton.image.sprite = OnSound;
            VolumeSlider.value = 5;
        }
    }



    public void SetQuality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }


    public void Start()
    {
        VolumeButton.image.sprite = OffSound;
        VolumeButton.onClick.AddListener(ButtonImages);
        Image ButtonImage = VolumeButton.GetComponent<Image>();
        PauuseMenuUI.SetActive(false);
        Settings.SetActive(false);
    }

    public void ButtonImages()
    {

        if (VolumeButton.image.sprite == OnSound)
            {
                VolumeButton.image.sprite = OffSound;
                VolumeSlider.value = 0;
            }
            else if (VolumeButton.image.sprite == OffSound)
            {
                VolumeButton.image.sprite = OnSound;
                VolumeSlider.value = 5;
            }
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
            SettingsMenu = false;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

   public void Resume()
    {
        Time.timeScale = 1;
        PauuseMenuUI.SetActive(false);
        Paude = false;
    }
    void Paused()
    {
        PauuseMenuUI.SetActive(true);
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
