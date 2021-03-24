using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;
    public int damage = 20;
    public static int death = 0;

    void OnTriggerEnter(Collider co)
    {
      
        Destroy(Projectile);
        if (co.tag.Equals("Enemies"))
        {
            GameStatsMechanics gameStatsMechanics =  co.gameObject.GetComponent<GameStatsMechanics>();
            gameStatsMechanics.TakeDamage(damage);

            Debug.Log(co.gameObject.name + co.gameObject.GetComponent<GameStatsMechanics>().health);

            if(co.gameObject.GetComponent<GameStatsMechanics>().health <= 0)
            {
                Destroy(co.gameObject);
                death++;
                Debug.Log("death: "+ death);
                
            }




        }
        
    }
}
