using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float SmoothFolow = 0.125f;

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothFolow);
        transform.position = SmoothPosition;
    
    }
    
}