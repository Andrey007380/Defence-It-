using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStatsMechanics : MonoBehaviour/*, IRespawnEnemy*/
{
    [Range(0f, float.MaxValue)] public float health;
    public float maxHealth = 100f;
    public float armor;
    public delegate void DeathZone();
    public event DeathZone OnDeathZone;

    public delegate void Death();
    public event Death OnDeath;


    public HealthBar healthBar;


    private void OnEnable()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;

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
        if(health <= 0f)
        {
            Debug.Log("Dead");
            OnDeath();
        }
    }
}
