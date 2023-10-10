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
    Material material;
    Color baseMaterial;
    float dropthrowTimer = 0f;
    
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        body = GetComponent<Rigidbody>();
        material = gameObject.GetComponent<Renderer>().material;
        baseMaterial = material.color;
    }

    void Update()
    {       
        if (transform.parent != null && dropthrowTimer < 0.5f)
        {
            dropthrowTimer += Time.deltaTime;
        }
        Opacity();
        Throw();
        Drop();
    }

    void Pickup()
    {
        if (transform.parent == null) 
        {
            collider.enabled = false;
            transform.parent = Player.transform;
            body.useGravity = false;
            body.isKinematic = true;
            transform.rotation = Player.transform.rotation;
            transform.position = Player.transform.position + Player.transform.forward;
        }
    }

    void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E) && dropthrowTimer >= 0.5f)
        {
            if (!isColliding && transform.parent != null)
            {
                transform.parent = null;
                collider.enabled = true;
                body.useGravity = true;
                body.isKinematic = false;
                dropthrowTimer = 0f;
            }
        }
    }

    void Throw()        
    {
        if (transform.parent != null && Input.GetMouseButtonDown(0) && !isColliding && dropthrowTimer >= 0.5f) 
        {
            transform.parent = null;
            collider.enabled = true;
            body.useGravity = true;
            body.isKinematic = false;
            body.AddForce(transform.forward * throwStrength, ForceMode.Impulse);
            dropthrowTimer = 0f;
        }
    }

    void Opacity() 
    { 
        if (transform.parent != null)
        {
            material.color = new Color(1f, 1f, 1f, 0f);
        }
        else if (transform.parent == null)
        {
            material.color = baseMaterial;
        }
    }
    public void Interact()
    {
        Pickup();
    }
}
