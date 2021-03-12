﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowingEnemy : EnemyBaseClass
{
    private NavMeshAgent PhisicBody;
    public FollowingEnemy(string Name, float Health, float Armor, float Damage, float MovmentSpeed, float AttackSpeed,NavMeshAgent Nav) : base(Name, Health, Armor, Damage, MovmentSpeed, AttackSpeed)
    {
        PhisicBody = Nav;
        PhisicBody.speed *= movmentSpeed;
    }

    public override void DealDamage(GameObject target)
    {
        base.DealDamage(target);
    }

    public override void Move(GameObject point)
    {
        PhisicBody.SetDestination(point.transform.position);
        base.Move(point);
    }

    public override void TakeDamage(float damage, string attakerName)
    {
        base.TakeDamage(damage, attakerName);
    }

   
}
