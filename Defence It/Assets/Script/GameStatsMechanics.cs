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
    public static event Death OnDeathScript;

    public static GameStatsMechanics Instance { get; set;}


    PauseMenu PauseMenu;
    PlayerController playerController;
    public HealthBar healthBar;

    private void Start()
    {
        Instance = this;
        PauseMenu = PauseMenu.Instance;
        playerController = PlayerController.Instance;
    }


    private void OnEnable()
    {
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    private void Update()
    {
        DeathScript();
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
        while(playerController.rigidbody.gameObject.GetComponent<GameStatsMechanics>().health <= 0)
        {
            PauseMenu.DeatScreenAndAds.SetActive(true);
            GameObject player = playerController.rigidbody.gameObject;
            player.transform.position = new Vector3(500f, 0.82f, 500f);
            player.GetComponent<GameStatsMechanics>().health = maxHealth;
            Time.timeScale = 0;

        }
        }
    public void Restart()
    {
        PauseMenu.DeatScreenAndAds.SetActive(false);
        Time.timeScale = 1;
        
    }
    }


