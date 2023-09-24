using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Range(1f, 100f)]
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] Vector3 JumpHeight = new Vector3(0f, 5f, 0f);

    [Range (0.1f,10f)]
    [SerializeField] float GroundDistance = 1.5f;
    [SerializeField] Vector3 GroundDirection = new Vector3(0f, -1f, 0f);
    bool CanJump;
    public LayerMask GroundMask;

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
        if (Physics.Raycast(transform.position, GroundDirection, GroundDistance, GroundMask))
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(JumpHeight, ForceMode.Impulse);
        }
    }
}