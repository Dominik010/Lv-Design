using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBridge : MonoBehaviour
{
    [SerializeField] private GameObject Bridge;
    [SerializeField] private Animator bANimator;

    private void Awake()
    {
        bANimator = Bridge.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bANimator.SetTrigger("WixonScheiﬂbarth");
    }
}
