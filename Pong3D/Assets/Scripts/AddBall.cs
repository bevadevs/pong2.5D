using UnityEngine;

public class AddBall : MonoBehaviour
{
    [SerializeField] GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(ball, transform.position, Quaternion.identity);
        // Metemos la nueva pelota en el array de pelotas de las que tiene que estar pendiende la IA
        IAPlayer02.balls = GameObject.FindGameObjectsWithTag("Ball");

        int ballListSize = 0;
        foreach (GameObject ball in IAPlayer02.balls)
        {
            ballListSize++;
        }
        Debug.Log("From AddBall: " + ballListSize);

        Destroy(gameObject);
    }
}
