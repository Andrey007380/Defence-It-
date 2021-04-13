using UnityEngine;

public class GameStatsMechanics : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;
    public float armor;



    public HealthBar healthBar;


    public void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;

    }


   public void TakeDamage(float damage)
    {
      health -= damage;
      healthBar.SetHealth(health);
    }

    public void DeathZone()
    {
        health -= 0.01f;
        healthBar.SetHealth(health);
    }
}
