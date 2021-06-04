using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 100f;
    public float angular; 

    public float transformX;
    public float transformY;

    public float RotateX;
    public float RotateY;

    public FixedJoystick joystick;
    public  FixedJoystick rotationJoystic;
    public Rigidbody rigidbody;
    LineRenderer lineRenderer;
    public static PlayerController Instance { get; private set; }

    void Awake()
    {
        Instance = this;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = rigidbody.GetComponent<LineRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }
   public void Rotation()
    {
        if (rotationJoystic.gameObject.active && rotationJoystic.Direction != new Vector2(0,0))
        {
            angular = Mathf.Atan2(rotationJoystic.Horizontal, rotationJoystic.Vertical) * Mathf.Rad2Deg;
            rigidbody.transform.rotation = Quaternion.Euler(new Vector3(0, angular, 0));
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transformX = joystick.Horizontal * moveSpeed;
        transformY = joystick.Vertical * moveSpeed;
        rigidbody.velocity = new Vector3(transformX * Time.deltaTime, 0, transformY * Time.deltaTime);

       
/*        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * 30 + transform.position);*/
        Rotation();
       
    }
}
