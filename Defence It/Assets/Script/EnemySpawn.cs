using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private int enemyMax = 50;
    private float spawnRadius = 40, time = 2f;
    private int enemysnow = 0;
    private bool maxReached = false; // Bool that stores the Information if the maximum is reached
    private Vector3 spawnPos; //Spawning an enemy
    EnemiesPool EnemiesPool;

    
    public void Start()
    {       
        StartCoroutine(SpawnEnemy());
        EnemiesPool = EnemiesPool.Instance;
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!maxReached)
            {

                spawnPos = GameObject.Find("Player").transform.position; //Spawning an enemy
                spawnPos += new Vector3(Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized * spawnRadius;

                EnemiesPool.Instance.GetFromPool(0, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(time);
                enemysnow++; // increase the enemy counter   
            }
                yield return null;
            maxReached = enemysnow >= enemyMax;
            }
    }
    
    public void LowerMaxEnemys()
    {
        enemysnow--;

    }
    private void OnEnable()
    {
        BulletMechanics.OnDeath += LowerMaxEnemys;
    }
    private void OnDisable()
    {
        BulletMechanics.OnDeath -= LowerMaxEnemys;
    }
}

