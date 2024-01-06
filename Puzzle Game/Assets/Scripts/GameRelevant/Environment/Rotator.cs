using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] public float rotSpeed = 20f;
    [SerializeField] public Vector3 rotDirection = new Vector3(0f, 1f, 0f);
    public bool isRotating = true;

    void FixedUpdate()
    {
        if (isRotating)
        {
            Rotationing();
        }
    }

    private void Rotationing()
    {
        transform.Rotate(rotDirection * rotSpeed * Time.deltaTime);       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Throwable"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") ||
            collision.gameObject.CompareTag("Throwable")) 
        { 
            collision.transform.parent = null; 
        }
    }
}
