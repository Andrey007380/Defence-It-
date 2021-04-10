using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseClass:IDamageble, IAttaker,IMoveble
{
    public string name { get; }
    public float heath { get; }
    public float armor { get; }
    public int damage { get; }
    public float movmentSpeed { get; }
    public float attackSpeed { get; }
    public float attackRange { get; }

    public EnemyBaseClass(string Name,float Health,float Armor, int Damage,float MovmentSpeed,float AttackSpeed)
    {
        name = Name;
        heath = Health;
        armor = Armor;
        damage = Damage;
        movmentSpeed = MovmentSpeed;
        attackSpeed = AttackSpeed;
        attackRange = 2.0f;
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
        Debug.Log(name + "получил урон от " + attakerName+" в размере "+damage);
    }
}
