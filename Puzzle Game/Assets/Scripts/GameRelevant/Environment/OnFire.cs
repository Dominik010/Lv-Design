using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnFire : MonoBehaviour, Interactive
{
    private Light myLight;
    private ParticleSystem myParticleSystem;
    public bool Off;

    [SerializeField] private string itemName;
    public string ItemName => itemName;
    void Start()
    {
        myLight = GetComponentInChildren<Light>(includeInactive: true);
        myParticleSystem = GetComponentInChildren<ParticleSystem>(includeInactive: true);
        if (Off)
        {
            myParticleSystem.Stop();
            myParticleSystem.Clear();
            myLight.enabled = false;
        }
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
