using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingEnemy : EnemyBaseClass
{
    public delegate void Dying();
    public  event Dying OnDying;
    private NavMeshAgent PhisicBody;
    private GameStatsMechanics UInform;
    public FollowingEnemy(string Name, int Health, float Armor, int Damage, float MovmentSpeed, float AttackSpeed, float AttackRange, NavMeshAgent Nav,GameStatsMechanics ui) : base(Name, Health, Armor, Damage, MovmentSpeed, AttackSpeed, AttackRange)
    {
        PhisicBody = Nav;
        UInform = ui;
        PhisicBody.speed *= movmentSpeed;
    }

    public override void DealDamage(GameObject target)
    {
        GameStatsMechanics TargetStats = target.GetComponent<GameStatsMechanics>();
        TargetStats.TakeDamage(damage);
        base.DealDamage(target);
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
        if (health - damage > 0)
        {
            health -= damage;
            UInform.TakeDamage(damage);
        }
        else
        {
            Died();
        }
        base.TakeDamage(damage, attakerName);
    }

    public override void Died() {
        OnDying.Invoke();
        base.Died();
    }
}
