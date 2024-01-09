using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMucke : MonoBehaviour
{
    public AudioSource Music;
    public AudioClip Day;
    public AudioClip Night;

    private void Awake()
    {
        Music = GetComponent<AudioSource>();
    }

    private void ChangeSound()
    {
        if (Music.clip == Day) 
        {
            Music.clip = Night;
            Music.Play();
        }
        else if (Music.clip == Night) 
        {
            Music.clip = Day;
            Music.Play();
        }
    }
}
