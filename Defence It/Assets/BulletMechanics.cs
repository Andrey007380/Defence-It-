using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMechanics : MonoBehaviour
{
    public Rigidbody rigidBody;

    void OnTriggerEnter(Collider co)
    {
        Destroy(gameObject);
    }
}
