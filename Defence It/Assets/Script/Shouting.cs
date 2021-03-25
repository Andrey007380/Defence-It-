using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shouting : MonoBehaviour
{
    public Transform FirePoint;
    public Transform PlayerPoint;
    public GameObject BulletPrefab;


    public float bulletForce = 15f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Aim();
        }

        if (Input.touchCount > 0)
        {

            if (Input.GetTouch(1).phase == TouchPhase.Began)
            {
                Aim();
            }
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Aim();
            }

        }


    }
    public void Aim()
    {
        RaycastHit _hit;
        if (Application.platform == RuntimePlatform.Android) 
        {
            Ray touchPos = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray touchPos1 = Camera.main.ScreenPointToRay(Input.GetTouch(1).position);
            if (Physics.Raycast(touchPos1, out _hit)|| Physics.Raycast(touchPos, out _hit))
            {
                PlayerPoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                FirePoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                
            }
            Shoot();
        }
        else
        {
            Ray touchPos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(touchPos, out _hit))
        {
                PlayerPoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                FirePoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                
            }
        Shoot();
        }
        
    }

    public void Shoot()
    {
    GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    rb.AddForce(FirePoint.forward* bulletForce, ForceMode.Impulse);
    }
}
