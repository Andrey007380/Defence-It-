using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimlpeFolowingEnemy : MonoBehaviour
{
    public FollowingEnemy EnemyBase;
    public GameObject Target;
    
    private void Start()
    {
        EnemyBase = new FollowingEnemy(Random.Range(0,99999).ToString(),1.0f,0,1,5,1,GetComponent<NavMeshAgent>());
        StartCoroutine(DoCheck());
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {if(Target!= null)
            EnemyBase.Move(Target);

            yield return new WaitForSeconds(10);

        }
    }
    private void FixedUpdate()
    {
       
    }
}
