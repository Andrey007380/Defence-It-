using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthAbowCharacter;
 
    public void SetMaxHealth(float health)
    {
        HealthAbowCharacter.maxValue = health;
        HealthAbowCharacter.value = health;
    }
    public void SetHealth(float health) 
    {
        HealthAbowCharacter.value = health;
    }
    public void Update()
    {
        // health above look to camera
/*        if (Camera.main)
        {
            HealthAbowCharacter.transform.rotation = Camera.main.transform.rotation;
        }*/
        
    }
}
