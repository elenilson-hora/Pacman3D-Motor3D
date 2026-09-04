using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private GameObject cameraMain;
    [SerializeField]
    private GameObject enemy;
    private Animator ani;

    private InputAction moveAction;

    [SerializeField]
    private TextMeshProUGUI textPonts;

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private int ponts;
    [SerializeField]
    private bool invencivel = false;
    [SerializeField]
    private bool atack = false;

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

        if (other.gameObject.CompareTag("Fish"))
        {
            ponts += 10;
            textPonts.text = "Pontos: " + ponts;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Yellow"))
        {
            invencivel = true;
            Debug.Log(invencivel);
            StartCoroutine(Yellow());
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Gray"))
        {
            atack = true;
            Debug.Log(atack);
            ponts += 200;
            StartCoroutine(Gray());
            Destroy(other.gameObject);
        }


    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !invencivel)
        {
            if (atack)
            {
                Destroy(enemy);
                Debug.Log("Sim");
            }
            else
            {
                Destroy(this.gameObject);
                Debug.Log("Não");
            }
            
        }
            
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

    private IEnumerator Yellow()
    {
        yield return new WaitForSeconds(2f);
        invencivel = false;
        Debug.Log(invencivel);
    }

    private IEnumerator Gray()
    {
        yield return new WaitForSeconds(2f);
        atack = false;
        Debug.Log(atack);
    }
}
