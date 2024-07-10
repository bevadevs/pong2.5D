using UnityEngine;

public class speedChange : MonoBehaviour
{
    GameObject[] balls;

    private void Awake()
    {
        balls = IAPlayer02.balls;
    }

    private void OnTriggerEnter(Collider c)
    {
        ChangeBallsSpeed();
        Destroy(gameObject);
    }

    // La bola es está quedando detenida tras la colisión
    private void ChangeBallsSpeed()
    {
        // Accedemos a cuál es el último jugador que ha tocado la bola
        string lastCollisionTag = BallMovement.lastCollision;
        foreach (GameObject ball in balls)
        {
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

            Vector3 velocity = ballRigidbody.velocity;

            if (lastCollisionTag == "Player01")
            {
                // Si la bola va hacia la derecha, la aceleramos, y si va hacia la izquierda, la ralentizamos
                if (velocity.x > 0)
                {
                    velocity *= 2.0f;
                }
                else if (velocity.x < 0)
                {
                    velocity *= 0.5f;
                }
            }
            else if (lastCollisionTag == "Player02")
            {
                // Si la bola va hacia la izquierda, la aceleramos, y si va hacia la derecha, la ralentizamos
                if (velocity.x > 0)
                {
                    velocity *= 0.5f;
                }
                else if (velocity.x < 0)
                {
                    velocity *= 2.0f;
                }
            }
        }
    }
}
