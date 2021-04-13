using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPool : MonoBehaviour
{
    
    private GameObject prefab;
    //Int = key
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

    private Queue<GameObject> availableObjcts = new Queue<GameObject>();

    static EnemiesPool _instance;
    public static EnemiesPool Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemiesPool>();
            }
            return Instance;
        }
    }
    public void Start()
    {
        prefab = Resources.Load<GameObject>("Spiders/prefabs");
    }

    // Start is called before the first frame update
   public void GetFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();
        //Make sure that the pool contains the key
        if (poolDictionary.ContainsKey(poolKey))
        {
            //Get first object of the queue
            GameObject objectToReuse = poolDictionary[poolKey].Dequeue();
            //Add object back to the end of the queue so we can reuse it again later
            poolDictionary[poolKey].Enqueue(objectToReuse);

            objectToReuse.SetActive(true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
        }

    
    }
    public void AddToPool(GameObject prefab, int poolSize)
    {
        //Key is unique for each prefab
        int poolKey = prefab.GetInstanceID();

        //Make sure the poolkey is already in our dictionary because it will cause errors if we don't
        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary.Add(poolKey, new Queue<GameObject>());
        }

        //Instantiate prefabs to create te pool
        for (int i = 0; i < poolSize; i++)
        {
            GameObject newObject = Instantiate(prefab) as GameObject;
            newObject.SetActive(false);
            //Add to the pool
            poolDictionary[poolKey].Enqueue(newObject);
        }
    }
}
