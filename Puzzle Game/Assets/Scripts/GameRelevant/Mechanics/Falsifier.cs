using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falsifier : MonoBehaviour
{
    [SerializeField] public GameObject FalseTrigger;
    [SerializeField] public FalsifyDependence TriggerBool;

    private void Start()
    {
        TriggerBool = FalseTrigger.GetComponent<FalsifyDependence>();
    }

    private void Update()
    {
        if (TriggerBool.setFalse == true)
        { 
            gameObject.SetActive(false);
        }
    }
}
