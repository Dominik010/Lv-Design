using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Range(1f, 100f)]
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Vector3 JumpHeight = new Vector3(0f, 4f, 0f);

    [Range (0.1f,10f)]
    [SerializeField] float GroundDistance = -0.2f;
    [SerializeField] Vector3 GroundDirection = new Vector3(0f, -1f, 0f);
    [SerializeField] Vector3 JumpDetection = new Vector3 (0.35f, 0.2f, 0.35f);
    [SerializeField] Quaternion BoxCastrot = Quaternion.identity;
    bool CanJump;
    public LayerMask GroundMask;
    public GameObject PlayerCam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // If the Player is walking, use
        if (rb.useGravity) 
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveSpeed = 4.5f;
            }
            else
            {
                moveSpeed = 3f;
            }
            Vector3 move = transform.right * x * moveSpeed / 1.5f + transform.forward * z * moveSpeed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        // If the Player is in an anti-gravity area, use
        else if (!rb.useGravity)
        {
            Vector3 move = PlayerCam.transform.right * x * moveSpeed / 1.5f + PlayerCam.transform.forward * z * moveSpeed;
            rb.velocity = new Vector3(move.x, move.y, move.z);            
        }

        // If the Player is falling, use
        if (x == 0f && z == 0f && rb.useGravity)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }
    }

    void Jump()
    {
        /* Better than ray since the Player can stay on the edge of an object and still
        be able to jump */
        if (Physics.BoxCast(transform.position,JumpDetection, GroundDirection
           ,BoxCastrot,GroundDistance, GroundMask))
        {
            CanJump = true;
        }
        else
        {
            CanJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump && rb.useGravity)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(JumpHeight, ForceMode.Impulse);
        }
    }
}