using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlank : MonoBehaviour
{
    [SerializeField] private GameObject Plank;
    private Animator pAnim;

    private void Awake()
    {
        pAnim = Plank.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            pAnim.SetTrigger("Activate");
        }
    }
}
