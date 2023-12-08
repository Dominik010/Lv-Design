using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUp : MonoBehaviour, Interactive
{
    [SerializeField] GameObject PlayerCam;
    [SerializeField] GameObject Player;
    [SerializeField] Transform originParent;
    [SerializeField] float throwStrength = 1000f;
    private new Collider collider;
    private Rigidbody body;
    public LayerMask PlayerMask;
    bool isColliding;
    bool Unavailable;
    Material material;
    Color baseMaterial;
    float dropthrowTimer = 0f;
    
    void Start()
    {
        collider = GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
        material = gameObject.GetComponent<MeshRenderer>().material;
        baseMaterial = material.color;
        originParent = transform.parent;
    }

    void Update()
    {       
        if (transform.parent == PlayerCam.transform)
        {
            if (dropthrowTimer < 0.5f)
            {
                dropthrowTimer += Time.deltaTime;
            }
            Opacity();
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
        if (transform.parent != PlayerCam.transform) 
        {
            MoreActive(true);
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: true);
            transform.parent = PlayerCam.transform;
            gameObject.layer = LayerMask.NameToLayer("Interaction");
            transform.SetPositionAndRotation(PlayerCam.transform.position + PlayerCam.transform.forward,
            PlayerCam.transform.rotation);
            Opacity();
        }
    }

    void Drop()
    {
        if (Input.GetKeyDown(KeyCode.E) && dropthrowTimer >= 0.5f)
        {
            if (!isColliding && transform.parent == PlayerCam.transform && !Unavailable)
            {
                transform.parent = originParent;
                MoreActive(false);
                dropthrowTimer = 0f;
                gameObject.layer = LayerMask.NameToLayer("Default");
                Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
                Opacity();
            }
        }
    }

    void Throw()        
    {
        if (transform.parent == PlayerCam.transform && Input.GetMouseButtonDown(0) 
            && !isColliding && dropthrowTimer >= 0.5f && !Unavailable) 
        {
            transform.parent = originParent;
            MoreActive(false);
            body.AddForce(transform.forward * throwStrength, ForceMode.Impulse);
            dropthrowTimer = 0f;
            gameObject.layer = LayerMask.NameToLayer("Default");
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
            Opacity();
        }
    }

    void Opacity() 
    { 
        if (transform.parent == PlayerCam.transform && !Unavailable)
        {
            material.color = new Color(1f, 1f, 1f, 0f);
        }
        else if (Unavailable)
        {
            material.color = new Color(1f, 0f, 0f, 0.3f);
        }

        if (transform.parent != PlayerCam.transform)
        {
            material.color = baseMaterial;
        }
    }
    public void Interact()
    {
        Pickup();
    }

    private void MoreActive(bool enabled)
    {
        collider.enabled = !enabled;
        body.useGravity = !enabled;
        body.isKinematic = enabled;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Environment") && transform.parent == PlayerCam.transform)
        {
            Unavailable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Environment") && transform.parent == PlayerCam.transform)
        {
            Unavailable = false;
        }
    }
}
