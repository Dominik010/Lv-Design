using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTheEnd : MonoBehaviour
{
    public int LeCount = 0;
    private Animator anim;
    private AudioSource aud;

    private void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        TheFinalCountdown();
    }

    private void TheFinalCountdown()
    {
        if (LeCount >= 2)
        {
            anim.SetTrigger("Open");
        }
    }

    void Victory()
    {
        aud.Play();
    }
}
