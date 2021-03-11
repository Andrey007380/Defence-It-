using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shouting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;
    

    public float bulletForce = 15f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
  public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(FirePoint.forward * bulletForce, ForceMode.Impulse);
    }



}
