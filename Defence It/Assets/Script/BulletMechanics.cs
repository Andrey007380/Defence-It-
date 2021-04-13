using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;
    private float damage = 20f;
    public delegate void Death();
    public static event Death OnDeath;
    public GameObject Drop;
    public static int death = 0;

    
    void OnTriggerEnter(Collider co)
    {
        Destroy(Projectile);
        Destroy(Projectile, 3);

        if (co.CompareTag("Enemies")|| co.CompareTag("Player"))
        {
            GameStatsMechanics gameStatsMechanics =  co.gameObject.GetComponent<GameStatsMechanics>();
            gameStatsMechanics.TakeDamage(damage);
            Debug.Log(co.gameObject.name + co.gameObject.GetComponent<GameStatsMechanics>().health);

            if(co.gameObject.GetComponent<GameStatsMechanics>().health <= 0)
            {
                OnDeath();
                EnemiesPool.Instance.AddToPool(co.gameObject, +1);
                Instantiate(Drop, transform.position, Drop.transform.rotation);
               
            }
        }   
    }
}
