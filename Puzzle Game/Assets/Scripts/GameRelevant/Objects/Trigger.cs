using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, Interactive
{
    public GameObject Door;
    [SerializeField] float Distance = 5f;
    bool interacted;

    [SerializeField] private AudioSource click;

    private void Start()
    {
        click = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        OpenDoor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Throwable"))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if (!interacted)
        {
            Door.transform.position += Vector3.up * Distance;
            interacted = true;
            click.Play();
        }
    }
}
