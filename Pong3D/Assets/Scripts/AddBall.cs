using System.Collections;
using UnityEngine;

public class AddBall : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] SFXComponent sfxComponent;
    [SerializeField] AudioClip clip;

    private void Awake()
    {
        // Quizás deba cambiarlo por que sea específicamente el componente del Spawner
        sfxComponent = FindObjectOfType<SFXComponent>();
    }

    private void OnTriggerEnter()
    {
        Instantiate(ball, transform.position, Quaternion.identity);
        // Metemos la nueva pelota en el array de pelotas de las que tiene que estar pendiende la IA
        IAPlayer02.balls = GameObject.FindGameObjectsWithTag("Ball");
        // Llamamos a la función para reproducir el sonido de recogida de power up
        sfxComponent.PlaySoundEffect(clip);

        Destroy(gameObject);
    }
}
