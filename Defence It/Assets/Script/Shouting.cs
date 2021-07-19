using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Shouting : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // Place from where bullets shoot
    [SerializeField] private Transform playerPoint; // Point in which player look at
    [SerializeField] private GameObject bulletPrefab; // bullet

    private float closerEnemy;
    private float Distance;
    GameObject closerDistance;


    public float bulletForce = 15f;
    public Button autoshoot;

    public void Start()
    {
        
        autoshoot = PlayerController.Instance.rotationJoystic.GetComponent<Button>();
        autoshoot.onClick.AddListener(RotationAim);
    }
    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
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
                playerPoint.transform.LookAt(new Vector3(_hit1.point.x, transform.position.y, _hit1.point.z));
                firePoint.transform.LookAt(new Vector3(_hit1.point.x, transform.position.y, _hit1.point.z));

            }

            /*  Ray touchPos = Camera.main.ScreenPointToRay(Input.touches[0].position); // First touch position to shoot
              if (Physics.Raycast(touchPos, out _hit))
              {
                  playerPoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                  firePoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
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
                playerPoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                firePoint.transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
                
            }
        Shoot();
        }
        
    }

    public void AutoAim()
    {
       GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        Transform nearestenemy = null;
        closerEnemy = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            Distance = Vector3.Distance(enemy.transform.position, PlayerController.Instance.rigidbody.position);
            if (Distance < closerEnemy)
            {
                nearestenemy = enemy.transform;
                closerEnemy = Distance;
            }

            playerPoint.transform.LookAt(nearestenemy);
            firePoint.transform.LookAt(nearestenemy);
        }
        
    }

    private void RotationAim()
    {
        AutoAim();
        Shoot();
    }

    public void Shoot()
    {
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    Rigidbody rb = bullet.GetComponent<Rigidbody>();
    rb.AddForce(firePoint.forward* bulletForce, ForceMode.Impulse);
    }
}
