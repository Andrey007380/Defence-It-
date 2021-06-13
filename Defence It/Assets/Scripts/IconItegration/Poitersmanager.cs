using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poitersmanager : MonoBehaviour
{
   [SerializeField] GameObject[] PosintersList;
    [SerializeField] EventIconShower eventIcon;
    void Start()
    {
        eventIcon.CreatePointer(new Vector3(500,0,500), PosintersList[0]);
    }

    
}
