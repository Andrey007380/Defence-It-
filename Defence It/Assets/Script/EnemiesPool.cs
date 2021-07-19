using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemiesPool : MonoBehaviour
{
    public static EnemiesPool Instance { get; private set; }

    //Int = key
    [SerializeField] private Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();
    [SerializeField] private Queue<GameObject> availableObjcts = new Queue<GameObject>();
    [SerializeField] private List<Pool> pools;

    [System.Serializable]
    public class Pool {
        public int Tag;
        public GameObject Prefab;
        public int Size;
    }

    public void Start()
    {
        foreach (Pool pool in pools)
        {
           
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab/* = Resources.Load<GameObject>("Spiders/Prefabs/Sphere")*/);
                obj.SetActive(false);
                availableObjcts.Enqueue(obj);
            }
            poolDictionary.Add(pool.Tag, availableObjcts);
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    public GameObject GetFromPool(int Tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(Tag))
        {
            Debug.LogWarning("Pool with Tag" + Tag + "not exist");
            return null;
        }
        //Get first object of the queue
        GameObject ObjectToSpawn = poolDictionary[Tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = position;
        ObjectToSpawn.transform.rotation = rotation;

      
        return ObjectToSpawn;
    }
    public void AddToPool(int Tag, GameObject Prefab)
    {
        if (!poolDictionary.ContainsKey(Tag))
        {
            Debug.LogWarning("Pool with Tag" + Tag + "not exist");
            return;
        }

        Prefab.SetActive(false);
        //Add to the pool
       availableObjcts.Enqueue(Prefab);

    }
}
