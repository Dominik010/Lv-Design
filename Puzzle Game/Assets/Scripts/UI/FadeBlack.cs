using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int runTime = Animator.StringToHash("Speed");

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _Animator.SetFloat(runTime, 1f);
            _Animator.SetTrigger(fadeOut);
            Debug.Log("Fading");
        }
    }
}
