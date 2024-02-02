using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    AudioSource aSource;
    [SerializeField] private AudioClip gClip;
    [SerializeField] private AudioClip hClip;
    [SerializeField] private AudioClip pClip;
    [SerializeField] private bool pButton;

    private void Awake()
    {
        aSource = GetComponent<AudioSource>();
    }
    void PlaySound()
    {
        aSource.clip = hClip;
        aSource.pitch = 0.9f;
        aSource.Play();
    }

    void StartSound()
    {
        if (pButton)
        {
            aSource.clip = gClip;
            aSource.pitch = 1f;
        }
        else if (!pButton)
        {
           aSource.pitch = 1.2f;
           aSource.clip = pClip;
        }
        aSource.Play();
    }
}
