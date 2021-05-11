using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(GameStatsMechanics))]
public class SimlpeFolowingEnemy : MonoBehaviour/*, IRespawnEnemy*/
{
    public FollowingEnemy EnemyBase;
    public GameObject Target;
    private RaycastHit raycast;
    public LayerMask AttackMask;
    EnemyPriority enemyPriority;
    GameStatsMechanics gameStats;

    private void Start()
    {
        
       
    }
    private void OnEnable()
    {
        gameStats = GetComponent<GameStatsMechanics>();
        enemyPriority = new EnemyPriority();
        EnemyBase = new FollowingEnemy(Random.Range(0, 99999).ToString(), 1.0f*EnemyUpgrader.Hpmulty, 0, Mathf.FloorToInt( 10*EnemyUpgrader.DamageMulty), 1, 1, GetComponent<NavMeshAgent>());
        gameStats.setStats(EnemyBase.heath);
        StartCoroutine(DoCheck());
    }
    IEnumerator DoCheck()
    {
        for (; ; )
        {
           Target= enemyPriority.GetNewTarget(Physics.OverlapSphere(transform.position, EnemyBase.attackRange*2, AttackMask));
            if (Target != null)


                if ((Target.transform.position - this.transform.position).magnitude <= EnemyBase.attackRange)
                {

                    EnemyBase.StopMoving();
                    yield return new WaitForSeconds(EnemyBase.attackSpeed);
                    if (Physics.Raycast(transform.position, Target.transform.position - this.transform.position, out raycast, EnemyBase.attackRange, AttackMask))
                    {
                        EnemyBase.DealDamage(raycast.collider.gameObject);
                    }
                }
                else { EnemyBase.Move(Target); }
            yield return new WaitForSeconds(0.3f);

        }
    }
}
