using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    public int Enemysnow = 0;
    public int enemyMax = 100;
    private bool maxReached = false; // Bool that stores the Information if the maximum is reached
    public Vector3 spawnPos; //Spawning an enemy
    EnemiesPool EnemiesPool;

    private float spawnRadius = 20, time = 0.50f;
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
                Enemysnow++; // increase the enemy counter   
            }
                yield return null;
            maxReached = Enemysnow >= enemyMax;
            }
    }
    
    public void LowerMaxEnemys()
        {
            Enemysnow--;

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

