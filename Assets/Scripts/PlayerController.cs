using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject cameraMain;
    private Animator ani;

    private InputAction moveAction;

    [SerializeField]
    private float speed = 10f;

    private Vector2 direction;
    private Vector3 vector3;
    private Vector3 offset;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        moveAction = InputSystem.actions.FindAction("Move");

        offset = cameraMain.transform.position - transform.position;

        ani.SetBool("IsEat", true);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube Left")
        {
            transform.position = new Vector3(4f, 0.5f, -0.3f); ;
        }
        else if(other.gameObject.name == "Cube Right")
        {
            transform.position = new Vector3(-4f, 0.5f, -0.3f);
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }

    private void Move()
    {
        Vector2 vector = moveAction.ReadValue<Vector2>();

        if (vector.y > 0f)
        {
            direction.y = 1f;
            direction.x = 0f;

            vector3.y = 0f;
        }
        else if (vector.y < 0f)
        {
            direction.y = -1f;
            direction.x = 0f;

            vector3.y = 180f;
        }
        else if (vector.x > 0f)
        {
            direction.y = 0f;
            direction.x = 1f;

            vector3.y = 90f;
        }
        else if (vector.x < 0f)
        {
            direction.y = 0f;
            direction.x = -1f;

            vector3.y = -90f;
        }

        rb.linearVelocity = new Vector3(direction.x, 0f, direction.y) * speed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(vector3);

        cameraMain.transform.position = transform.position + offset;
    }
}
