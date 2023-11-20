using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] public float rotSpeed = 20f;
    [SerializeField] public Vector3 rotDirection = new Vector3(0f, 0f, 1f);
    public bool isRotating = true;

    void Update()
    {
        Rotationing();
    }

    private void Rotationing()
    {
        if (isRotating)
        {
            transform.Rotate(rotDirection * rotSpeed * Time.deltaTime);
        }
    }
}
