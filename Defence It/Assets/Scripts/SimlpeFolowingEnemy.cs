using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimlpeFolowingEnemy : MonoBehaviour
{
    public FollowingEnemy EnemyBase;
    public GameObject Target;
    private RaycastHit raycast;
    public LayerMask AttackMask;
    private EnemyPriority enemyPriority;
    private void Start()
    {
        EnemyBase = new FollowingEnemy(Random.Range(0, 99999).ToString(), 1.0f, 0, 10, 1, 1, GetComponent<NavMeshAgent>());
        enemyPriority = new EnemyPriority() ;
        StartCoroutine(DoCheck());
        
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
            Target = enemyPriority.GetNewTarget(Physics.OverlapSphere(transform.position, 10f));
            if (Target != null) {


                if ((Target.transform.position - this.transform.position).magnitude <= EnemyBase.attackRange)
                {

                    EnemyBase.StopMoving();
                    yield return new WaitForSeconds(EnemyBase.attackSpeed);
                    if (Physics.Raycast(transform.position, Target.transform.position - this.transform.position, out raycast, EnemyBase.attackRange, AttackMask))
                    {
                        EnemyBase.DealDamage(raycast.collider.gameObject);
                    }

                }
                else { EnemyBase.Move(Target); } }
            yield return new WaitForSeconds(0.3f);

        }
    }

  
}
