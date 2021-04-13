using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField]

    private GameObject[] EnemiesRespawns;
    public float spawnRadius = 20, time = 2.50f;
    public int Enemysnow = 0;
    public int enemyMax = 100;
    private bool maxReached = false; // Bool that stores the Information if the maximum is reached
    public Vector3 spawnPos; //Spawning an enemy
    private List<GameObject> EnemyPoolList = new List<GameObject>();
    public List<int> used_numbers;

    float prefabTimer;
    int prefabNumber;


    public void Start()
    {
        prefabTimer = time;
        foreach (GameObject enemy in EnemyPoolList)
        {
            EnemiesPool.Instance.AddToPool(enemy, 1);
        }
            StartCoroutine(SpawnEnemy());
        
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!maxReached) {

                spawnPos = GameObject.Find("Player").transform.position; //Spawning an enemy
                spawnPos += new Vector3( Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized * spawnRadius;
                prefabTimer = Time.deltaTime;
                if (prefabTimer <= 0)
                {
                    prefabNumber = Random.Range(0, EnemyPoolList.Count);
                }
                while (used_numbers.Contains(prefabNumber))
                {
                    prefabNumber = Random.Range(0, EnemyPoolList.Count);
                }
                used_numbers.Add(prefabNumber);

                Instantiate(EnemyPoolList[prefabNumber], spawnPos, Quaternion.identity);
                EnemiesPool.Instance.GetFromPool(EnemyPoolList[prefabNumber],spawnPos,Quaternion.identity);
                if (used_numbers.Count >= 10)
                {
                    used_numbers.RemoveRange(0, used_numbers.Count - 5);
                }

                yield return new WaitForSeconds(time);
                        Enemysnow++; // increase the enemy counter
               /* }*/
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

