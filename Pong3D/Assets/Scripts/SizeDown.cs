using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeDown : MonoBehaviour
{
    [SerializeField] GameObject Player01;
    [SerializeField] GameObject Player02;

    private void Awake()
    {
        Player01 = GameObject.FindGameObjectWithTag("Player01");
        Player02 = GameObject.FindGameObjectWithTag("Player02");
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        // Vemos con qué pelota ha colisionado y recuperamos su componente BallMovement para acceder a su última colisión con un jugador
        GameObject ballCollisioned = collider.gameObject;
        BallMovement bmc = ballCollisioned.GetComponent<BallMovement>();
        string lastCollisionTag = bmc.lastCollision;

        if (lastCollisionTag == "Player01")
        {
            Player02.transform.localScale -= new Vector3(0, 1, 0);
        }
        else if (lastCollisionTag == "Player02")
        {
            Player01.transform.localScale -= new Vector3(0, 1, 0);
        }

        Destroy(gameObject);
    }
}
