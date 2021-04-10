using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool Paude = false;
    public static bool SettingsMenu = false;
    public GameObject PauuseMenuUI;
    public GameObject Settings;
    public void Start()
    {
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
}
