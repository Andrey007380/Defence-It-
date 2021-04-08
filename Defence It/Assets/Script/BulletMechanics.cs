using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;
    public int damage = 20;
    public delegate void Death();
    public static event Death OnDeath;
    public GameObject Drop;
    public static int death = 0;


    void OnTriggerEnter(Collider co)
    {
      
        Destroy(Projectile);
        Destroy(Projectile, 3);

        if (co.CompareTag("Enemies")|| co.CompareTag("CharacterBase"))
        {
            GameStatsMechanics gameStatsMechanics =  co.gameObject.GetComponent<GameStatsMechanics>();
            gameStatsMechanics.TakeDamage(damage);

            Debug.Log(co.gameObject.name + co.gameObject.GetComponent<GameStatsMechanics>().health);

            if(co.gameObject.GetComponent<GameStatsMechanics>().health <= 0)
            {
                OnDeath();
                Destroy(co.gameObject);
                Instantiate(Drop, transform.position, Drop.transform.rotation);
                
                
            }




        }
        
    }
   

}
