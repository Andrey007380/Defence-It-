using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick rotationJoystic;
    public Rigidbody rigidbody;

    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private FixedJoystick joystick;

    private float angular;

    private float transformX;
    private float transformY;

    private float RotateX;
    private float RotateY;
   
    LineRenderer lineRenderer;
    public static PlayerController Instance { get; private set; }

   private void Awake()
    {
        Instance = this;
       
    }
    // Start is called before the first frame update
    private void Start()
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
   private void FixedUpdate()
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
