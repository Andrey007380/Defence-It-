using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text timerup;
    public Text killedEnemies;
    public Text dropcounter;

    float current_time = 0;
    public int avgFrameRate;
    public void Update()
    {
        current_time += 1 * Time.deltaTime;
        int seconds = (int)(current_time % 60);
        int minute = (int)(current_time / 60) % 60;
        string Timerstring = string.Format("{0:00}:{1:00}", minute, seconds);
        timerup.text = "Live time: " + Timerstring;
        KilledEnemies();
    }
    public void KilledEnemies()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
        killedEnemies.text = "Kills: " + BulletMechanics.death.ToString() /*+ avgFrameRate.ToString() + " FPS"*/;
        dropcounter.text = Drop.bullets.ToString();
    }
}
