using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 100f;
    public float angularSpeed = 0.5f;

    public float rotationX;
    public float rotationY;

    public float transformX;
    public float transformY;

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
        transformX = joystick.Horizontal * moveSpeed;
        transform.Translate(transformX * Time.deltaTime, 0, 0 );

/*        rotationX = joystick.Horizontal * angularSpeed;
        transform.Rotate(0, rotationX, 0);*/

        transformY = joystick.Vertical * moveSpeed;
        transform.Translate(0, 0, transformY * Time.deltaTime);

/*        rotationY = joystick.Horizontal * angularSpeed;
        transform.Rotate(0, rotationY, 0);*/

    }
}
