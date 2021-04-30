using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
     
    [SerializeField] GameObject PlayerData;
    [SerializeField] GameObject CountersData;
    [SerializeField] GameObject BaseData;


    private void Start()    {
         string Path = Application.dataPath;
        string MobilePATH = Application.persistentDataPath;
    }
    public void SaveToJson()
    {

    }


}
