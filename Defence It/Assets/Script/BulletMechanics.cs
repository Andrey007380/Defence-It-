
using UnityEngine;


public class BulletMechanics : MonoBehaviour
{
    public GameObject Projectile;


    void OnTriggerEnter(Collider co)
    {
       /* gameStats = FindObjectOfType<GameStatsMechanics>();
*/

        Destroy(Projectile);
        if (co.tag.Equals("Enemies"))
        {
            co.gameObject.GetComponent<GameStatsMechanics>().health = FindObjectOfType<GameStatsMechanics>().TakeDamage();
            Debug.Log(co.gameObject.name + co.gameObject.GetComponent<GameStatsMechanics>().health);
            
           

        }
    }
}