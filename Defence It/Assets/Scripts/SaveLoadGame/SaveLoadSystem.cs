using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadSystem : MonoBehaviour
{
    [SerializeField] GameObject[] NpcandplayersData;
    [SerializeField] GameObject SetingsData;
    [SerializeField] GameObject CountersData;
    [SerializeField] GameObject Enemymultiplyer;

    class SavedDataUnit{
        Transform transform;
        GameStatsMechanics gameStatsMechanics;
         public string name { get; set; }
        public SavedDataUnit(string name,Transform transform,GameStatsMechanics gm)
        {
            this.name = name;
            this.transform = transform;
            this.gameStatsMechanics = gm;
        }
         
        }
    private void Start()    {
         
    }
    public void SaveTo()
    { string NamesOfNpc="";
        foreach (GameObject item in NpcandplayersData)
        {
            NamesOfNpc += item.name + " ";
            SavedDataUnit savedDataUnit = new SavedDataUnit(item.name, item.transform, item.GetComponent<GameStatsMechanics>());
            PlayerPrefs.SetString(savedDataUnit.name, Serializer.Serialiser<SavedDataUnit>(savedDataUnit));
        }
        PlayerPrefs.SetString("Names", NamesOfNpc);
        PlayerPrefs.SetString("Counters", CountersData.GetComponent<Timer>().GetCounters());
        PlayerPrefs.SetString("Settings", SetingsData.GetComponent<PauseMenu>().GetVolume() + " " + SetingsData.GetComponent<PauseMenu>().GetQualityIndex());


        PlayerPrefs.Save();
    }


}
