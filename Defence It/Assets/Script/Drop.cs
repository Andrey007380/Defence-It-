using UnityEngine;
public class Drop : MonoBehaviour
{
    public static int bullets = 0;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Player"))
        {

            Destroy(gameObject);
            bullets++;


        }


    }

}
