using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour, Interactive
{
    [SerializeField] float Speed = 5f;
    [SerializeField] float Time = 1f;
    [SerializeField] Vector3 MoveDirection;
    Rigidbody rb;
    bool move;
    bool interacted;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }
    public void Interact()
    {
        move = true;
    }

    void Move()
    {
        if (move && !interacted)
        {
            rb.isKinematic = false;
            rb.velocity = MoveDirection * Speed;
            StartCoroutine(StopMove());
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    private IEnumerator StopMove()
    {
        yield return new WaitForSeconds(Time);
        move = false;
        interacted = true;
        rb.isKinematic = true;
    }
}
