using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemiesPool : MonoBehaviour
{
    //Int = key
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();
    public Queue<GameObject> availableObjcts = new Queue<GameObject>();
    [System.Serializable]
    public class Pool {
        public int tag;
        public GameObject prefab;
        public int size;
    }


    public List<Pool> pools;

    public static EnemiesPool Instance { get; private set; }
   

    public void Start()
    {
        foreach (Pool pool in pools)
        {
           
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab/* = Resources.Load<GameObject>("Spiders/prefabs/Sphere")*/);
                obj.SetActive(false);
                availableObjcts.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, availableObjcts);
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public GameObject GetFromPool(int tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "not exist");
            return null;
        }
        //Get first object of the queue
        GameObject ObjectToSpawn = poolDictionary[tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

      
        return ObjectToSpawn;
    }
    public void AddToPool(int tag, GameObject prefab)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "not exist");
            return;
        }

        prefab.SetActive(false);
        //Add to the pool
       availableObjcts.Enqueue(prefab);

    }
}
