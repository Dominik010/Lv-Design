using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Animator pAnim;
    private bool TwoWay;

    private void Start()
    {
        pAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!TwoWay)
        {
            pAnim.SetTrigger("Pressed");
            TwoWay = true;
            pAnim.ResetTrigger("Return");
            return;
        }
        if (TwoWay)
        {
            pAnim.SetTrigger("Return");
            TwoWay = false;
            pAnim.ResetTrigger("Pressed");
        }
    }
}
