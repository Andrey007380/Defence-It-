using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text timerup;
    public Text killedEnemies;

    float current_time = 0;

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
        killedEnemies.text = "Kills: " + BulletMechanics.death.ToString();
    }
}
