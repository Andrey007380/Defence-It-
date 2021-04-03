using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;
    public int damage = 20;
    public static int death = 0;
    public GameObject Drop;


    void OnTriggerEnter(Collider co)
    {
      
        Destroy(Projectile);
        Destroy(Projectile, 3);

        if (co.CompareTag("Enemies"))
        {
            GameStatsMechanics gameStatsMechanics =  co.gameObject.GetComponent<GameStatsMechanics>();
            gameStatsMechanics.TakeDamage(damage);

            Debug.Log(co.gameObject.name + gameStatsMechanics.health);

            if(gameStatsMechanics.health <= 0)
            {
                Destroy(co.gameObject);
                Instantiate(Drop, transform.position, Drop.transform.rotation);
                death++;
                
            }




        }
        
    }
   

}
