using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    [SerializeField] private AudioSource aud;
    Rigidbody rb;
    Collider col;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = rb.GetComponent<Collider>();
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
        yield return new WaitForSeconds(2f);
        rb.useGravity = true;
        rb.isKinematic = false;
        col.isTrigger = true;
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }
}
