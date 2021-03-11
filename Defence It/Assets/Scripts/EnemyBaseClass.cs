using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseClass:IDamageble, IAttaker,IMoveble
{
    public string name { get; }
    public double heath { get; }
    public double armor { get; }
    public double damage { get; }
    public double movmentSpeed { get; }
    public double attackSpeed { get; }
 
    public EnemyBaseClass(string Name,double Health,double Armor, double Damage,double MovmentSpeed,double AttackSpeed)
    {
        name = Name;
        heath = Health;
        armor = Armor;
        damage = Damage;
        movmentSpeed = MovmentSpeed;
        attackSpeed = AttackSpeed;
    }

    public virtual void DealDamage(GameObject target)
    {
        Debug.Log(name + " нанёс урон " + target.name+" в размере " + damage);
    }

    public virtual void Move(Vector3 point)
    {
        Debug.Log(name + " переместился в позицию " +point);
    }

    public virtual void TakeDamage(double damage,string attakerName)
    {
        Debug.Log(name + "получил урон от " + attakerName+" в размере "+damage);
    }
}
