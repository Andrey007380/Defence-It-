using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class AutoLoadLevel : MonoBehaviour
{
    public GameObject other;
    public GameObject player;

    public void Start()
    {
        other = gameObject;
    }
    public void AutoLoad()
    {

        if (Vector3.Distance(player.transform.position, other.transform.position) < 1130)
        {
            other.GetComponent<Terrain>().enabled = true;
        }
        else
        {
            other.GetComponent<Terrain>().enabled = false;

        }
    }
    public void Update()
    {
        AutoLoad();
      
    }
}
