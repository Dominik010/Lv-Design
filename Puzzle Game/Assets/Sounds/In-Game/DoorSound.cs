using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    AudioSource dSource;

    private void Awake()
    {
        dSource = GetComponent<AudioSource>();
    }
    void DoorAudio()
    {
        dSource.Play();
    }
}
