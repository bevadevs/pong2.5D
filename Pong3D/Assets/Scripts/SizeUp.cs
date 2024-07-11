using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeUp : MonoBehaviour
{
    [SerializeField] GameObject Player01;
    [SerializeField] GameObject Player02;
    [SerializeField] SFXComponent sfxComponent;
    [SerializeField] AudioClip clip;

    private void Awake()
    {
        Player01 = GameObject.FindGameObjectWithTag("Player01");
        Player02 = GameObject.FindGameObjectWithTag("Player02");

        // Quizás deba cambiarlo por que sea específicamente el componente del Spawner
        sfxComponent = FindObjectOfType<SFXComponent>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        // Vemos con qué pelota ha colisionado y recuperamos su componente BallMovement para acceder a su última colisión con un jugador
        GameObject ballCollisioned = collider.gameObject;
        BallMovement bmc = ballCollisioned.GetComponent<BallMovement>();
        string lastCollisionTag = bmc.lastCollision;

        if (lastCollisionTag == "Player01")
        {
            Player01.transform.localScale += new Vector3(0, 1, 0);
        }
        else if (lastCollisionTag == "Player02")
        {
            Player02.transform.localScale += new Vector3(0, 1, 0);
        }

        // Llamamos a la función para reproducir el sonido de recogida de power up
        sfxComponent.PlaySoundEffect(clip);

        Destroy(gameObject);
    }
}
