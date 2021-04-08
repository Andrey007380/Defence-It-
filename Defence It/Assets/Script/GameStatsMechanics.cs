using UnityEngine;

public class GameStatsMechanics : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int armor;



    public HealthBar healthBar;


    public void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;

    }


   public void TakeDamage(int damage)
    {
      health -= damage;
      healthBar.SetHealth(health);
    }
    
   
}
