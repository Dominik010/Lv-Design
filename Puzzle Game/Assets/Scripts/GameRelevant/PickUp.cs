using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUp : MonoBehaviour, Interactive
{
    [SerializeField] GameObject PlayerCam;
    [SerializeField] GameObject Player;
    [SerializeField] float throwStrength = 1000f;
    private new BoxCollider collider;
    private Rigidbody body;
    public LayerMask PlayerMask;
    bool isColliding;
    bool Unavailable;
    Material material;
    Color baseMaterial;
    float dropthrowTimer = 0f;
    
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        body = GetComponent<Rigidbody>();
        material = gameObject.GetComponent<MeshRenderer>().material;
        baseMaterial = material.color;
    }

    void Update()
    {       
        if (transform.parent != null)
        {
            if (dropthrowTimer < 0.5f)
            {
                dropthrowTimer += Time.deltaTime;
            }
        }
        else
        {
            return;
        }
        Throw();
        Drop();
    }

    void Pickup()
    {
        if (transform.parent == null) 
        {
            collider.enabled = false;
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: true);
            transform.parent = PlayerCam.transform;
            body.useGravity = false;
            body.isKinematic = true;
            transform.rotation = PlayerCam.transform.rotation;
            transform.position = PlayerCam.transform.position + PlayerCam.transform.forward;
            Opacity();
        }
    }

    void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E) && dropthrowTimer >= 0.5f)
        {
            if (!isColliding && transform.parent != null && !Unavailable)
            {
                transform.parent = null;
                collider.enabled = true;
                body.useGravity = true;
                body.isKinematic = false;
                dropthrowTimer = 0f;
                Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
                Opacity();
            }
        }
    }

    void Throw()        
    {
        if (transform.parent != null && Input.GetMouseButtonDown(0) && !isColliding && dropthrowTimer >= 0.5f && !Unavailable) 
        {
            transform.parent = null;
            collider.enabled = true;
            body.useGravity = true;
            body.isKinematic = false;
            body.AddForce(transform.forward * throwStrength, ForceMode.Impulse);
            dropthrowTimer = 0f;
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
            Opacity();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Environment") && transform.parent != null)
        {
            Unavailable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Environment") && transform.parent != null)
        {
            Unavailable = false;
        }
    }
}
