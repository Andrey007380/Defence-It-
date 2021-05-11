using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text timerup;
    public Text killedEnemies;
    public TextMeshProUGUI dropcounter;
    public delegate void MonsterUpgrade();
    public static event MonsterUpgrade OnMonsterUpgrade;
    public int death {  set; get; } = 0;

    public float current_time { set; get; } = 0;
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
        killedEnemies.text = "Kills: " + death.ToString();
        dropcounter.text = Drop.bullets.ToString();
    }
    public void KillCouter()
    {
        death++;
    }
    private void OnEnable()
    {
        BulletMechanics.OnDeath += KillCouter;
        EnemyUpgrader.Enable();
    }
    private void OnDisable()
    {
        BulletMechanics.OnDeath -= KillCouter;
        EnemyUpgrader.Disable();
    }
    public void SetCounters(int time,int killed,int bullet)
    {
        current_time = time;
        death = killed;
        Drop.bullets = bullet;

    }
    public string GetCounters()
    { 
        return current_time +","+ death + ","+Drop.bullets.ToString();
    }
}
