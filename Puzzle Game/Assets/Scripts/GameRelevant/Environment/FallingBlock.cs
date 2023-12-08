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
        SetPhysics(false);
        oriPos = transform.localPosition;
    }

    private void SetPhysics(bool enabled)
    {
        rb.useGravity = enabled;
        rb.isKinematic = !enabled;
        col.isTrigger = enabled;      
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
            SetPhysics(true);
        }
    }

    private void ReturnToOrigin()
    {
        if (trig.Return == true)
        {
            SetPhysics(false);
            transform.localPosition = oriPos;
        }
    }
}
