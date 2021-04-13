using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

        if (Vector3.Distance(player.transform.position, other.transform.position) < 1430)
        {
            other.GetComponent<Terrain>().enabled = true;
        }
        else
        {
            other.GetComponent<Terrain>().enabled = false;

        }
    }
    public void DeathZone()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameStatsMechanics gameStatsMechanics = player.GetComponent<GameStatsMechanics>();
        if (player.transform.position.x > 1800|| player.transform.position.x < -800|| player.transform.position.z < -800|| player.transform.position.z > 1800)
        {
            gameStatsMechanics.DeathZone();
        }else if(player.transform.position.y < 0)
        {
            player.transform.position = (new Vector3(player.transform.position.x, 1, player.transform.position.z));
        }
    }


    void FixedUpdate()
    {
        DeathZone();
        AutoLoad();
     
    }
}
