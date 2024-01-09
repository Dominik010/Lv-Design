using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PickUp : MonoBehaviour, Interactive
{
    [SerializeField] GameObject PlayerCam;
    [SerializeField] GameObject Player;
    [SerializeField] Transform originParent;
    [SerializeField] float throwStrength = 10f;
    [SerializeField] private AudioSource boxAud;
    [SerializeField] private AudioClip _pickUp;
    [SerializeField] private AudioClip _drop;
    [SerializeField] private AudioClip _throw;
    private new Collider collider;
    private Rigidbody body;
    public LayerMask PlayerMask;
    bool isColliding;
    bool Unavailable;
    Material material;
    Color baseMaterial;
    float dropthrowTimer = 0f;
    float timer = 0f;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    void Start()
    {
        collider = GetComponent<Collider>();
        body = GetComponent<Rigidbody>();
        material = gameObject.GetComponent<MeshRenderer>().material;
        baseMaterial = material.color;
        originParent = transform.parent;
        boxAud = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {       
        if (transform.parent == PlayerCam.transform)
        {
            transform.SetPositionAndRotation(Vector3.Lerp(transform.position,
            PlayerCam.transform.position + PlayerCam.transform.forward * 1.5f, 0.05f)
            , Quaternion.Lerp(transform.rotation, PlayerCam.transform.rotation, 0.05f));

            if (dropthrowTimer < 0.5f)
            {
                dropthrowTimer += Time.deltaTime;
            }
            Opacity();
            Drop();
            Throw();
        }

        if (timer <= 1f)
        {
            timer += Time.deltaTime;
        }
    }

    void Pickup()
    {
        if (transform.parent != PlayerCam.transform) 
        {
            MoreActive(true);
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: true);
            transform.parent = PlayerCam.transform;
            gameObject.layer = LayerMask.NameToLayer("Interaction");
            Opacity();
            boxAud.clip = _pickUp;
            boxAud.Play();
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
                gameObject.layer = LayerMask.NameToLayer("CanInteract");
                Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
                Opacity();
            }
        }
    }

    void Throw()        
    {
        if (transform.parent == PlayerCam.transform && Input.GetMouseButtonDown(0)
            && !isColliding && dropthrowTimer >= 0.5f && !Unavailable && gameObject.tag == "Throwable")
        {
            transform.parent = originParent;
            MoreActive(false);
            body.AddForce(transform.forward * body.mass * throwStrength, ForceMode.Impulse);
            dropthrowTimer = 0f;
            gameObject.layer = LayerMask.NameToLayer("CanInteract");
            Physics.IgnoreCollision(collider, Player.GetComponent<Collider>(), ignore: false);
            Opacity();
            boxAud.clip = _throw;
            boxAud.Play();
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
        if (other.gameObject && transform.parent == PlayerCam.transform)
        {
            Unavailable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject && transform.parent == PlayerCam.transform)
        {
            Unavailable = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timer >= 1f)
        {
            boxAud.clip = _drop;
            boxAud.Play();
            timer = 0f;
        }
    }
}
