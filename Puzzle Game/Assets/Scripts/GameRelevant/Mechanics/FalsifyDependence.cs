using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalsifyDependence : MonoBehaviour
{
    [SerializeField] public bool setFalse;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            setFalse = true;
        }
    }
}
