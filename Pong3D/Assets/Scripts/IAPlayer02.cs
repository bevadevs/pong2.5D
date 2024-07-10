using UnityEngine;


public class IAPlayer02 : MonoBehaviour
{
    [SerializeField] float speed;
    int direction;
    [SerializeField] Rigidbody rb;
    public static GameObject[] balls;

    private void Awake()
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        foreach (GameObject ball in balls)
        {
            // Comprobamos qué bola está más cerca para seguir su movimiento
            if (Vector3.Distance(ball.transform.position, transform.position) < Vector3.Distance(balls[0].transform.position, transform.position))
            {
                balls[0] = ball;
            }
        }

        if (balls[0].transform.position.y > transform.position.y)
        {
            direction = 1;
        }
        else if (balls[0].transform.position.y < transform.position.y)
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        Vector3 movement = new Vector3(0, direction * speed * Time.deltaTime, 0);

        rb.MovePosition(transform.position + movement);
    }
}
