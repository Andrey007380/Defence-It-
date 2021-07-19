﻿using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;

    public delegate void Death();
    public static event Death OnDeath;

    public GameObject Drop;
    public static int death = 0;

    private float damage = 20f;

    private void OnTriggerEnter(Collider co)
    {
        Destroy(Projectile);
        Destroy(Projectile, 3);

        if (co.CompareTag("Enemies")|| co.CompareTag("Player"))
        {
            GameStatsMechanics gameStatsMechanics =  co.gameObject.GetComponent<GameStatsMechanics>();
            gameStatsMechanics.TakeDamage(damage);
            Debug.Log(co.gameObject.name + co.gameObject.GetComponent<GameStatsMechanics>().health);

            if(co.gameObject.GetComponent<GameStatsMechanics>().health <= 0)
            {
                OnDeath();               
                EnemiesPool.Instance.AddToPool(0,co.gameObject);
                Instantiate(Drop, transform.position, Drop.transform.rotation);
               
            }
        }   
    }

}
