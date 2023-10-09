using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, Interactive
{
    [SerializeField] GameObject Player;
    [SerializeField] float throwStrength = 1000f;
    private new BoxCollider collider;
    private Rigidbody body;
    bool isColliding;
    
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Drop();
        Throw();
    }

    void Pickup()
    {
        if (transform.parent == null) 
        {
            transform.parent = Player.transform;
            collider.enabled = false;
            body.useGravity = false;
            body.isKinematic = true;
            transform.rotation = Player.transform.rotation;
        }
    }

    void Drop()
    {
        if (transform.parent == Player.transform)
        {
            if (Input.GetKeyDown(KeyCode.E) && !isColliding)
            {
                transform.parent = null;
                collider.enabled = true;
                body.useGravity = true;
                body.isKinematic = false;
            }
        }
    }

    void Throw()        
    {
        if (transform.parent != null && Input.GetMouseButtonDown(0)) 
        {
            transform.parent = null;
            collider.enabled = true;
            body.useGravity = true;
            body.isKinematic = false;
            body.AddForce(transform.forward * throwStrength, ForceMode.Impulse);
        }
    }

    public void Interact()
    {
        Pickup();
    }
}
