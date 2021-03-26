using UnityEngine;

public class Drop : MonoBehaviour
{
    public int bullets = 0;
    BulletMechanics bullet;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Player"))
        {
            
            Destroy(gameObject);
            bullets++;
            Debug.Log(bullets);


        }

    }
}
