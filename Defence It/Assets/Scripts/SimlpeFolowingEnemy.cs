using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimlpeFolowingEnemy : MonoBehaviour
{
    public LayerMask AttackLayer;
    public FollowingEnemy EnemyBase;
    public GameObject Target= null;
    public GameStatsMechanics SincStats;
    private RaycastHit raycastInfo;
    private void Start()
    {
        SincStats = GetComponent<GameStatsMechanics>();
           EnemyBase = new FollowingEnemy(Random.Range(0,99999).ToString(),100,0,1,1,1,2.5f,GetComponent<NavMeshAgent>(), SincStats);
        StartCoroutine(DoCheck());
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {if(Target!= null)
            
            Debug.Log((Target.transform.position - this.transform.position).magnitude);
            if ((Target.transform.position - this.transform.position).magnitude <= EnemyBase.attackRange)
            {
                EnemyBase.StopMoving();
                yield return new WaitForSeconds(EnemyBase.attackSpeed);
                Ray AttackRay = new Ray(this.transform.position,Target.transform.position- this.transform.position );
                
                if (Physics.Raycast(AttackRay,out raycastInfo, EnemyBase.attackRange, AttackLayer )){ EnemyBase.DealDamage(raycastInfo.collider.gameObject);  }
               
            }
            else { EnemyBase.Move(Target); }
            yield return new WaitForSeconds(0.3f);

        }
        
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    private void OnEnable()
    {
        EnemyBase.OnDying += Death;
    }
    private void OnDisable()
    {
        EnemyBase.OnDying -= Death;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(this.transform.position, Target.transform.position - this.transform.position);
    }
}
