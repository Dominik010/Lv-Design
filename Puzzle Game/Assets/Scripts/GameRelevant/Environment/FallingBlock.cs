using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private AudioSource aud;
    Rigidbody rb;
    Collider col;
    [SerializeField] private bool Platform;
    [SerializeField] private bool ThisIsAnObject;
    [SerializeField] public Vector3 oriPos;
    [SerializeField] private GameObject _Trigger;
    [SerializeField] private Trigger trig;
    [SerializeField] private float TimeToFall = 2f;

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
        if (Platform)
        {
            rb.useGravity = enabled;
            rb.isKinematic = !enabled;
            col.isTrigger = enabled;
        }
        else if (ThisIsAnObject)
        {
            rb.useGravity = enabled;
            rb.isKinematic = !enabled;
        }
    }

    private void Update()
    {
        ReturnToOrigin();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Platform)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(Fall());
                aud.Play();
            }
        }
        else if (ThisIsAnObject)
        {
            if (collision.gameObject.CompareTag("Throwable"))
            {
                SetPhysics(true);
            }
        }
    }

    private IEnumerator Fall()
    {
        if (trig.Return == false)
        {
            yield return new WaitForSeconds(TimeToFall);
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
