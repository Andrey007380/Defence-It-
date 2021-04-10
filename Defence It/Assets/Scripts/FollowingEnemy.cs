using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingEnemy : EnemyBaseClass
{
    private NavMeshAgent PhisicBody;
    public FollowingEnemy(string Name, float Health, float Armor, int Damage, float MovmentSpeed, float AttackSpeed,NavMeshAgent Nav) : base(Name, Health, Armor, Damage, MovmentSpeed, AttackSpeed)
    {
        PhisicBody = Nav;
        PhisicBody.speed *= movmentSpeed;
    }

    public override void DealDamage(GameObject target)
    {
        if (target.GetComponent<GameStatsMechanics>())
        {
            target.GetComponent<GameStatsMechanics>().TakeDamage(damage);
            
        }
    }

    public override void Move(GameObject point)
    {
        PhisicBody.isStopped = false;
        PhisicBody.SetDestination(point.transform.position);
        
    }
    public void StopMoving()
    {
        PhisicBody.isStopped = true; 
    }

    public override void TakeDamage(int damage, string attakerName)
    {
        base.TakeDamage(damage, attakerName);
    }

   
}
