using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private AudioSource aud;
    Rigidbody rb;
    Collider col;
    [SerializeField] public Vector3 oriPos;
    [SerializeField] private GameObject _Trigger;
    [SerializeField] private Trigger trig;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = rb.GetComponent<Collider>();
        aud = GetComponent<AudioSource>();
        trig = _Trigger.GetComponent<Trigger>();
    }

    private void Start()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        col.isTrigger = false;
        oriPos = transform.localPosition;
    }

    private void Update()
    {
        ReturnToOrigin();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            aud.Play();
        }
    }

    private IEnumerator Fall()
    {
        if (trig.Return == false)
        {
            yield return new WaitForSeconds(2f);
            rb.useGravity = true;
            rb.isKinematic = false;
            col.isTrigger = true;
        }
    }

    private void ReturnToOrigin()
    {
        if (trig.Return == true)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            col.isTrigger = false;
            transform.localPosition = oriPos;
        }
    }
}
