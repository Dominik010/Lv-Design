using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Animator pAnim;
    private bool TwoWay;
    [SerializeField] private bool pp3;
    [SerializeField] AudioSource ppSource;
    [SerializeField] private GameObject Child;
    [SerializeField] private AudioSource cSource;


    private void Start()
    {
        pAnim = GetComponent<Animator>();
        ppSource = GetComponent<AudioSource>();
        cSource = Child.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!TwoWay)
        {
            if (other.gameObject.CompareTag("Player") 
                || other.gameObject.CompareTag("Throwable") && other.gameObject.layer != LayerMask.NameToLayer("Interaction")
                || other.gameObject.CompareTag("Stone") && other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
            {
                ppSource.Play();
                pAnim.SetTrigger("Pressed");
            }
        }

        else if (TwoWay) 
        {
            if (other.gameObject.CompareTag("Player")
                || other.gameObject.CompareTag("Throwable") && other.gameObject.layer != LayerMask.NameToLayer("Interaction")
                || other.gameObject.CompareTag("Stone") && other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
            {
                ppSource.Play();
                pAnim.SetTrigger("Return");
            }
        }
        TwoWay = !TwoWay;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!pp3 && other.gameObject.CompareTag("Player") 
            || !pp3 && other.gameObject.CompareTag("Throwable") && other.gameObject.layer != LayerMask.NameToLayer("Interaction")
            || !pp3 && other.CompareTag("Stone") && other.gameObject.layer != LayerMask.NameToLayer("Interaction"))
        {
            pAnim.SetTrigger("Pressed");
            pAnim.ResetTrigger("NotPressed");
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!pp3)
        {
            pAnim.SetTrigger("NotPressed");
            pAnim.ResetTrigger("Pressed");
        }

        ppSource.Stop();
    }

    void Rolling()
    {
        cSource.Play();
    }
}
