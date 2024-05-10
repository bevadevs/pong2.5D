using UnityEngine;

public class speedChange : MonoBehaviour
{
    GameObject Player01;
    GameObject Player02;
    GameObject[] balls;

    private void Awake()
    {
        Player01 = GameObject.FindGameObjectWithTag("Player01");
        Player02 = GameObject.FindGameObjectWithTag("Player02");
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

        if (lastCollisionTag == "Player01")
        {
            foreach (GameObject ball in balls)
            {
                // Si la bola va hacia la derecha, la aceleramos, y si va hacia la izquierda, la ralentizamos
                if (ball.GetComponent<Rigidbody>().velocity.x > 0)
                {
                    ball.GetComponent<Rigidbody>().velocity *= 2;
                }
                else if (ball.GetComponent<Rigidbody>().velocity.x < 0)
                {
                    ball.GetComponent<Rigidbody>().velocity /= 2;
                }
            }
        }
        else if (lastCollisionTag == "Player02")
        {
            foreach (GameObject ball in balls)
            {
                // Si la bola va hacia la izquierda, la aceleramos, y si va hacia la derecha, la ralentizamos
                if (ball.GetComponent<Rigidbody>().velocity.x > 0)
                {
                    ball.GetComponent<Rigidbody>().velocity /= 2;
                }
                else if (ball.GetComponent<Rigidbody>().velocity.x < 0)
                {
                    ball.GetComponent<Rigidbody>().velocity *= 2;
                }
            }
        }
    }
}
