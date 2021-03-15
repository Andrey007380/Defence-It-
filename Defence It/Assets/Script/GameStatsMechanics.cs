using UnityEngine;

public class GameStatsMechanics : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public Stats armor;
    public int damage;
    public int death = 0;


    public HealthBar healthBar;


    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

    }


   public int TakeDamage(int damage = 20)
    {
      int value = health -= damage;
        
        healthBar.SetHealth(health);

        if(value <= 0)
        {
            death++;
            
        }
        return value;
    }
    
}
