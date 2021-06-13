using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyUpgrader
{
    
public static float Hpmulty { get; private set; } = 1.0f;
 public static float DamageMulty { get; private set; } = 1.0f;
     static void AddStats()
    {
        Hpmulty += 0.02f;
        DamageMulty += 0.01f;

    }
   public static void  Enable()
    {
        Timer.OnMonsterUpgrade+=AddStats;
    }
    public static void Disable()
    {
        Timer.OnMonsterUpgrade -= AddStats;
    }
    public static void SetValue(float hp,float dm) {
        Hpmulty = hp;
        DamageMulty = dm;
    }
}
