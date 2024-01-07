using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnFire : MonoBehaviour, Interactive
{
    private Light myLight;
    private ParticleSystem myParticleSystem;
    public bool Off;
    void Start()
    {
        if (Off)
        {
            myParticleSystem.Stop();
            myParticleSystem.Clear();
            myLight.enabled = false;
        }
        myLight = GetComponentInChildren<Light>(includeInactive: true);
        myParticleSystem = GetComponentInChildren<ParticleSystem>(includeInactive: true);
    }

    public void Interact()
    {
        if (myParticleSystem.isPlaying) 
        { 
            myParticleSystem.Stop();
            myParticleSystem.Clear();
            myLight.enabled = false;
        }
        else if (myParticleSystem.isStopped)
        {
            myParticleSystem.Play();
            myLight.enabled = true;
        }
    }
}
