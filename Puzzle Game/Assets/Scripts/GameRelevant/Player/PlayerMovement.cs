using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [Range(1f, 100f)]
    [SerializeField] float moveSpeed = 7f;
    float originalSpeed;
    float runSpeed;
    [SerializeField] Vector3 JumpHeight = new Vector3(0f, 5f, 0f);

    [Range (0.1f,10f)]
    [SerializeField] float GroundDistance = 1f;
    [SerializeField] Vector3 GroundDirection = new Vector3(0f, -1f, 0f);
    [SerializeField] Vector3 JumpDetection = new Vector3 (0.5f, 0.2f, 0.5f);
    [SerializeField] Quaternion BoxCastrot = Quaternion.identity;
    bool CanJump;
    public LayerMask GroundMask;
    public GameObject PlayerCam;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalSpeed = moveSpeed;
        runSpeed = moveSpeed * 1.5f;
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
        
        if (rb.useGravity) 
        {
            Vector3 move = transform.right * x * moveSpeed / 1.5f + transform.forward * z * moveSpeed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        else if (!rb.useGravity)
        {
            Vector3 move = PlayerCam.transform.right * x * moveSpeed / 1.5f + PlayerCam.transform.forward * z * moveSpeed;
            rb.velocity = new Vector3(move.x, move.y, move.z);            
        }

        if (x == 0f && z == 0f && rb.useGravity)
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = originalSpeed;
        }
    }

    void Jump()
    {
        if (Physics.BoxCast(transform.position,JumpDetection, GroundDirection,BoxCastrot,GroundDistance, GroundMask))
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