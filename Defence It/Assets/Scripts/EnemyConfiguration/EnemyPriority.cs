using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPriority
{
    public GameObject CurrentTarget { private set; get; } = new GameObject("Nobody");
    private Dictionary<string, int> ValueOfTag = new Dictionary<string, int>();
  public EnemyPriority()
    {
        ValueOfTag.Add("Player",100);
        ValueOfTag.Add("CharacterMainBase", 40);
        ValueOfTag.Add("BaseTurrel",50);
        ValueOfTag.Add("Nobody", 0);
    }
    public EnemyPriority(Dictionary<string, int>x)
    {
        ValueOfTag = x;
    }
    public EnemyPriority(string[] TagList, int[] ValueList)
    {
        for(int i =0; i<TagList.Length;i++)
        {
            ValueOfTag.Add(TagList[i], ValueList[i]);
        }
    }
    public GameObject GetNewTarget(Collider[] colliders)
    {
        foreach( Collider col  in colliders)
        {if(ValueOfTag.ContainsKey(col.name))
           if(ValueOfTag[col.name] > ValueOfTag[CurrentTarget.name])
            {
                CurrentTarget = col.gameObject;
            }
        }
        if (CurrentTarget.name != "Nobody")
        {
            return null;
        }else
        return CurrentTarget;
    }
   
}
