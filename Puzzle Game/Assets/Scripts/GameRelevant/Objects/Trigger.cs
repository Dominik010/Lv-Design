using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, Interactive
{
    // For one-time use of Trigger
    [SerializeField] public bool turnOff = true;
    [SerializeField] private bool interacted;

    // Opens a Door
    public GameObject Door;
    [SerializeField] float Distance = 5f;
    [SerializeField] private bool Opener = true;

    // Return a Platform to its original Position
    [SerializeField] private bool Returner = true;
    [SerializeField] public bool Return = false;

    // Change Rotation of a Gameobject
    public GameObject RotTarget;
    private Rotator rotator;
    [SerializeField] private bool Rotater = false;

    [SerializeField] private AudioSource click;

    private void Start()
    {
        click = GetComponent<AudioSource>();
        rotator = RotTarget.GetComponent<Rotator>();
    }

    public void Interact()
    {
        if (Opener)
        {
            OpenDoor();
        }
        else if (Returner)
        {
            ReturnPlatform();
        }
        else if (Rotater)
        {
            ChangeRot();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Throwable"))
        {
            if (Opener)
            {
                OpenDoor();
            }
            else if (Returner)
            {
                ReturnPlatform();
            }
            else if (Rotater)
            {
                ChangeRot();
            }
        }
    }

    void OpenDoor()
    {
        if (!interacted)
        {
            click.Play();
            Door.transform.position += Vector3.up * Distance;
            if (turnOff)
            {
                interacted = true;
            }
        }
    }

    void ReturnPlatform()
    {
        if (!interacted)
        {
            click.Play();
            Return = true;
            StartCoroutine(JustForOneFvckingBool());
        }
    }

    private IEnumerator JustForOneFvckingBool()
    {
        yield return new WaitForSeconds(2);
        Return = false;
    }

    void ChangeRot()
    {
        if (!interacted)
        {
            click.Play();
            rotator.rotDirection *= -1;
        }
    }
}
