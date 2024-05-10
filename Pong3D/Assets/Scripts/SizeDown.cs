using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeDown : MonoBehaviour
{
    // Accedemos a cuál es el último jugador que ha tocado la bola
    string lastCollisionTag = BallMovement.lastCollision;

    [SerializeField] GameObject Player01;
    [SerializeField] GameObject Player02;

    private void Awake()
    {
        Player01 = GameObject.FindGameObjectWithTag("Player01");
        Player02 = GameObject.FindGameObjectWithTag("Player02");
    }

    private void OnTriggerEnter(Collider c)
    {
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
