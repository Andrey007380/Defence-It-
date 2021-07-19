using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] NpcandplayersData;
    [SerializeField] private GameObject SetingsData;
    [SerializeField] private GameObject CountersData;
    [SerializeField] private GameObject Enemymultiplyer;

    class SavedDataUnit{
        public Transform transform { get; set; }
        public GameStatsMechanics gameStatsMechanics { get; set; }
        public string name { get; set; }
        public SavedDataUnit(string name,Transform transform,GameStatsMechanics gm)
        {
            this.name = name;
            this.transform = transform;
            this.gameStatsMechanics = gm;
        }
         
        }
 
    public void SaveTo()
    { string NamesOfNpc="";
        foreach (GameObject item in NpcandplayersData)
        {
            NamesOfNpc += item.name + ",";
            SavedDataUnit savedDataUnit = new SavedDataUnit(item.name, item.transform, item.GetComponent<GameStatsMechanics>());
            PlayerPrefs.SetString(savedDataUnit.name, Serializer.Serialiser<SavedDataUnit>(savedDataUnit));
        }
        PlayerPrefs.SetString("Names", NamesOfNpc);
        PlayerPrefs.SetString("Counters", CountersData.GetComponent<Timer>().GetCounters());
        PlayerPrefs.SetString("Settings", SetingsData.GetComponent<PauseMenu>().GetVolume() + "," + SetingsData.GetComponent<PauseMenu>().GetQualityIndex());
        PlayerPrefs.SetString("EnemyStats", EnemyUpgrader.DamageMulty + "," + EnemyUpgrader.Hpmulty);

        PlayerPrefs.Save();
    }
    public void Load()
    {
        List<string> nameOfNpc = new List<string>();

       nameOfNpc.AddRange( PlayerPrefs.GetString("Names").Split(','));
        foreach  (string name in nameOfNpc)
        {
            SavedDataUnit savedDataUnit= Serializer.DeSerialiser<SavedDataUnit>( PlayerPrefs.GetString(name));
            GameObject gameObject= NpcandplayersData[nameOfNpc.IndexOf(name)];
            gameObject.transform.position = savedDataUnit.transform.position;
            gameObject.name = savedDataUnit.name;
            gameObject.GetComponent<GameStatsMechanics>().health = savedDataUnit.gameStatsMechanics.health;
        }
        
        string[] stringcounteiner = PlayerPrefs.GetString("Counters").Split(',');
        int[] counters = new int[stringcounteiner.Length];
        for (int i = 0; i < stringcounteiner.Length; i++)
        {
            counters[i] = int.Parse(stringcounteiner[i]);
        }
        CountersData.GetComponent<Timer>().SetCounters(counters[0], counters[1], counters[2]);
        stringcounteiner= PlayerPrefs.GetString("Settings").Split(',');
        SetingsData.GetComponent<PauseMenu>().SetVolume(float.Parse(stringcounteiner[0]));
        SetingsData.GetComponent<PauseMenu>().SetQuality(int.Parse(stringcounteiner[1]));
        stringcounteiner= PlayerPrefs.GetString("EnemyStats").Split(',');
        EnemyUpgrader.SetValue(float.Parse(stringcounteiner[0]), float.Parse(stringcounteiner[1]));
    }

}
