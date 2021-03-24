using UnityEngine;

public class GameStatsMechanics : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int armor;
    public int death;


    public HealthBar healthBar;


    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

    }


   public void TakeDamage(int damage)
    {
      health -= damage;
      healthBar.SetHealth(health);
    }
    
}
