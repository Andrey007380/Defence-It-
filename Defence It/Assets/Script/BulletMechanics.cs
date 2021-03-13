using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;

    void OnTriggerEnter(Collider co)
    {
        if (co.name != "Player")
        {

            Destroy(Projectile);
        }
    }

}
