using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shouting : MonoBehaviour
{
    public Transform FirePoint; // Place from where bullets shoot
    public Transform PlayerPoint; // Point in which player look at
    public GameObject BulletPrefab; // bullet


    public float bulletForce = 15f;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Aim();
        }

        if (Input.touchCount > 0)
        {

            if (Input.touches[1].phase == TouchPhase.Began) //Second touch shooting
            {
                Aim();
            }
           /* if (Input.touches[0].phase == TouchPhase.Began) // First touch shooting
            {
                Aim();
            }*/

        }


    }
    public void Aim()
    {
        RaycastHit _hit1;
        RaycastHit _hit;
        

        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer) 
        {
            Application.targetFrameRate = 60;
            if (EventSystem.current.IsPointerOverGameObject()) //Ignore Ui elements
                return;

            Ray touchPos1 = Camera.main.ScreenPointToRay(Input.touches[1].position); // Second touch position to shoot
            if (Physics.Raycast(touchPos1, out _hit1))
            {
                PlayerPoint.transform.LookAt(new Vector3(_hit1.point.x, transform.position.y, _hit1.point.z));
                FirePoint.transform.LookAt(new Vector3(_hit1.point.x, transform.position.y, _hit1.point.z));

            }

            /*  Ray touchPos = Camera.main.ScreenPointToRay(Input.touches[0].position); // First touch position to shoot
              if (Physics.Raycast(touchPos, out _hit))
              {
                  PlayerPoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                  FirePoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
              }*/
            Shoot();
        }
        else
        {
            if (EventSystem.current.IsPointerOverGameObject()) //Ignore Ui elements
                return;

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
