using UnityEngine;

public class AddBall : MonoBehaviour
{
    [SerializeField] GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        // Añadir un "saca con el espacio" para que el jugador sepa sacar la bola
        Instantiate(ball, transform.position, Quaternion.identity);
        // Metemos la nueva pelota en el array de pelotas de las que tiene que estar pendiende la IA
        IAPlayer02.balls = GameObject.FindGameObjectsWithTag("Ball");
        Destroy(gameObject);
    }
}
