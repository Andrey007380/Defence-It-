using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 100f;
    public float angularSpeed = 0.5f;

    public float transformX;
    public float transformY;

    public FixedJoystick joystick;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transformX = joystick.Horizontal * moveSpeed;
        transformY = joystick.Vertical * moveSpeed;
        rigidbody.velocity = new Vector3(transformX * Time.deltaTime, 0, transformY * Time.deltaTime);
        




    }
}
