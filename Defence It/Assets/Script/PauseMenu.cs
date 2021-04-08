using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public static bool Paude = false;
    public GameObject PauuseMenuUI;
    public void Start()
    {
        PauuseMenuUI.SetActive(false);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
   public void Resume()
    {
        PauuseMenuUI.SetActive(false);
        Time.timeScale = 1;
        Paude = false;
    }
    void Paused()
    {
        PauuseMenuUI.SetActive(true);
        Time.timeScale = 0;
        Paude = true;
    }
}
