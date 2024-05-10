using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02Movement : MonoBehaviour
{
    [SerializeField] int direction;
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = 1;

        }
        else if (Input.GetKey(KeyCode.DownArrow))
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
