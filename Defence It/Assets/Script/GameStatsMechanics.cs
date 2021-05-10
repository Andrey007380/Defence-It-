using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatsMechanics : MonoBehaviour/*, IRespawnEnemy*/
{
    public float health;
    public float maxHealth = 100f;
    public float armor;
    public delegate void DeathZone();
    public event DeathZone OnDeathZone;


    public HealthBar healthBar;


    public void OnEnable()
    {
        setStats();

    }

    public void setStats()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }
    public  void setStats(float hp)
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
}
