using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthAbowCharacter;
 
    public void SetMaxHealth(int health)
    {
        HealthAbowCharacter.maxValue = health;
        HealthAbowCharacter.value = health;
    }
    public void SetHealth(int health) 
    {
        HealthAbowCharacter.value = health;
    }
    public void Update()
    {
        if (Camera.main)
        {
            HealthAbowCharacter.transform.rotation = Camera.main.transform.rotation;
        }
    }
}
