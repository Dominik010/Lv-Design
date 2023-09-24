using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 100f)]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] Vector3 JumpHeight = new Vector3(0f, 5f, 0f);

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x * moveSpeed / 1.5f + transform.forward * z * moveSpeed;

        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        if (x == 0f && z == 0f)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    void Jump() 
    { 
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(JumpHeight, ForceMode.Impulse);
        }
    }
}
