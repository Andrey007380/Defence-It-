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
    private List<GameObject> enemies = new List<GameObject>();
    public Vector3 spawnPos; //Spawning an enemy
    
    


    public void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!maxReached) {

                EnemiesRespawns = (GameObject[])Resources.LoadAll<GameObject >("Spiders/prefabs") as GameObject[];
Debug.Log(EnemiesRespawns.Length);
                spawnPos = GameObject.Find("Player").transform.position; //Spawning an enemy
                spawnPos += new Vector3( Random.insideUnitSphere.x, 0, Random.insideUnitSphere.z).normalized * spawnRadius;
                
                foreach (GameObject enemy in EnemiesRespawns)
                {
                    Instantiate(enemy, spawnPos, Quaternion.identity);

                        yield return new WaitForSeconds(time);
                        Enemysnow++; // increase the enemy counter
                    }
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

