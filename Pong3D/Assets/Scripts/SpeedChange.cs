using System.ComponentModel;
using UnityEngine;

public class speedChange : MonoBehaviour
{
    GameObject[] balls;
    [SerializeField] SFXComponent sfxComponent;
    [SerializeField] AudioClip clip;

    private void Awake()
    {
        balls = IAPlayer02.balls;

        // Quiz�s deba cambiarlo por que sea espec�ficamente el componente del Spawner
        sfxComponent = FindObjectOfType<SFXComponent>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Vemos con qu� pelota ha colisionado y recuperamos su componente BallMovement para pas�rselo a la funci�n
        GameObject ballCollisioned = collider.gameObject;
        BallMovement bmc = ballCollisioned.GetComponent<BallMovement>();
        ChangeBallsSpeed(bmc);

        // Llamamos a la funci�n para reproducir el sonido de recogida de power up
        sfxComponent.PlaySoundEffect(clip);

        Destroy(gameObject);
    }

    private void ChangeBallsSpeed(BallMovement bm)
    {
        // Accedemos a cu�l es el �ltimo jugador que ha tocado la bola
        string lastCollisionTag = bm.lastCollision;

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
