using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatsMechanics : MonoBehaviour
{
    [Range(0f, float.MaxValue)] public float health;
    public float maxHealth = 100f;
    public float armor;

    public delegate void DeathZone();
    public event DeathZone OnDeathZone;

    public delegate void Death();
    public static event Death OnDeathScript;

    public HealthBar healthBar;
    public static GameStatsMechanics Instance { get; set; }

    public void OnEnable()
    {
        Instance = this;
        setStats();
    }
    public void Update()
    {
        DeathScript();
    }
    public void setStats()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }
    public void setStats(float hp)
    {
        maxHealth =Mathf.FloorToInt( hp);
        setStats();
    }
    public void TakeDamage(float damage)
    {
      health -= damage;
      healthBar.SetHealth(health);
    }

    public void DeathZoneScript()
    {
        OnDeathZone();
        health -= 0.01f;
        healthBar.SetHealth(health);
    }
    public void DeathScript()
    {
        GameObject player = PlayerController.Instance.rigidbody.gameObject;
        while (player.GetComponent<GameStatsMechanics>().health < 0)
        {
            PauseMenu.Instance.DeatScreenAndAds.SetActive(true); 
            player.transform.position = new Vector3(500f, 0.82f, 500f);
            player.GetComponent<GameStatsMechanics>().health = maxHealth;
            Time.timeScale = 0;

        }
    }
    public void Restart()
    {
        PauseMenu.Instance.DeatScreenAndAds.SetActive(false);
        Time.timeScale = 1;

    }
}
