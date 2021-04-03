using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseClass:IDamageble, IAttaker,IMoveble
{
    public string name { get; }
    public int health { get; protected set; }
    public float armor { get; protected set; }
    public int damage { get; protected set; }
    public float movmentSpeed { get; protected set; }
    public float attackSpeed { get; protected set; }
    public float attackRange { get; }

    public EnemyBaseClass(string Name,int Health,float Armor, int Damage,float MovmentSpeed,float AttackSpeed,float AttackRange)
    {
        name = Name;
        health = Health;
        armor = Armor;
        damage = Damage;
        movmentSpeed = MovmentSpeed;
        attackSpeed = AttackSpeed;
        attackRange = AttackRange;
    }

    public virtual void DealDamage(GameObject target)
    {
        Debug.Log(name + " нанёс урон " + target.name+" в размере " + damage);
    }

    public virtual void Move(GameObject point)
    {
        Debug.Log(name + " переместился в позицию " +point);
    }

    public virtual void TakeDamage(int damage,string attakerName)
    {
        Debug.Log(name + " получил урон от " + attakerName+" в размере "+damage);
    }
    public virtual void Died() { Debug.Log(name + " Погиб" ); }
}
