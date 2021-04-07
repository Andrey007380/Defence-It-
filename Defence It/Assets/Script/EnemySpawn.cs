using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    public float spawnRadius = 20, time = 2.50f;
    public int Enemysnow = 0;
    public int enemyMax = 100;
    private bool maxReached = false; // Bool that stores the Information if the maximum is reached

    public Vector3 spawnPos; //Spawning an enemy
    public GameObject enemies;
    public int death = 0;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!maxReached) { 
            spawnPos = GameObject.Find("Player").transform.position; //Spawning an enemy
            spawnPos += new Vector3(Random.insideUnitSphere.x, 0 ,Random.insideUnitSphere.z).normalized * spawnRadius;
            GameObject.Instantiate(enemies, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(time);
                Enemysnow++; // increase the enemy counter
            }
            yield return null;
        }
    }
     
   
    public void Update()
    {
        
        maxReached = LowerMaxEnemys() >= enemyMax;
    }

    public int LowerMaxEnemys()
    {
        if (BulletMechanics.death > 0)
        {
            death++;
            if (death > 0) 
            { 
            Enemysnow--;
            death--;
            }
        }
        return Enemysnow;
    }

}

