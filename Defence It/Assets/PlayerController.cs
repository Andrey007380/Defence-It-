using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 0.5f;
    public float rotationX;
    public float rotationY;

    public Joystick joystick;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationX = joystick.Horizontal * moveSpeed;
        transform.Translate(rotationX * moveSpeed, 0, 0 );

        rotationY = joystick.Vertical * moveSpeed;
        transform.Translate(0, 0, rotationY * moveSpeed);

    }
}
