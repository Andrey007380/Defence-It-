using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 7f;
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
        rotationX = joystick.Horizontal * moveSpeed * Time.deltaTime;
        rotationY = joystick.Vertical * moveSpeed*Time.deltaTime;

        transform.Translate(rotationX  , 0, rotationY );

    }
}
