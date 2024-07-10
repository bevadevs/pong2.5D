using System.Collections;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Rigidbody rb;
    public static string lastCollision;
    float initialSpeed = 3f;
    [SerializeField] float speed;
    [SerializeField] int impactsCounter;
    [SerializeField] bool isTimeToServe;
    Vector3 direction;
    Vector3[] initialDirections = new Vector3[]
    {
        new Vector3(1, 1, 0), new Vector3(1, 0.5f, 0), new Vector3(1, -0.5f, 0), new Vector3(1, -1, 0),
        new Vector3(-1, 1, 0), new Vector3(-1, 0.5f, 0), new Vector3(-1, -0.5f, 0), new Vector3(-1, -1, 0)
    };

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        speed = initialSpeed;
        direction = initialDirections[Random.Range(0, 8)];
        rb.velocity = (direction * speed);
    }

    void Update()
    {
        Serve();
    }

    IEnumerator Respawn(string tag)
    {
        yield return new WaitForSeconds(0.3f);
        rb.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(0.7f);

        impactsCounter = 0;
        isTimeToServe = true;

        if (tag == "GoalArea01")
        {
            gameObject.transform.position = new Vector3(-7, 0, 0);
            // Solo direcciones hacia la derecha
            direction = initialDirections[Random.Range(0, 4)];
        }
        else if (tag == "GoalArea02")
        {
            gameObject.transform.position = new Vector3(7, 0, 0);
            // Solo direcciones hacia la izquierda
            direction = initialDirections[Random.Range(4, 8)];
        }

        // Metemos la nueva pelota en el array de pelotas de las que tiene que estar pendiende la IA
        // NO ESTÁ FUNCIONANDO
        IAPlayer02.balls = GameObject.FindGameObjectsWithTag("Ball");

        yield return direction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Guardamos con qué jugador ha sido la última colisión
        lastCollision = collision.gameObject.tag;

        // Calculamos la dirección de rebote cuando colisiona con otro objeto
        Vector3 collisionNormal = collision.GetContact(0).normal;
        direction = Vector3.Reflect(direction, collisionNormal);

        // Cada 4 toques que se le den a la pelota, aumentamos su velocidad
        if ((collision.collider.tag == "Player01") || (collision.collider.tag == "Player02"))
        {
            impactsCounter++;
        }
        if (impactsCounter == 4)
        {
            speed++;
            impactsCounter = 0;
        }

        rb.velocity = (direction * speed);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if ((trigger.tag == "GoalArea01") || (trigger.tag == "GoalArea02"))
        {
            scoreManager.AddScore(trigger.tag);
            StartCoroutine(Respawn(trigger.tag));
        }
    }

    private void Serve()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isTimeToServe)
            {
                speed = initialSpeed;
                rb.velocity = (direction * speed);
                isTimeToServe = false;
            }
        }
    }
}
