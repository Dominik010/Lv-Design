using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OnFire : MonoBehaviour, Interactive
{
    private Light myLight;
    private ParticleSystem myParticleSystem;
    public bool Off;

    public bool lv3;
    [SerializeField] private ToTheEnd _end;

    public AudioSource _switch;

    [SerializeField] private string itemName;
    [SerializeField] private GameObject Counter;
    [SerializeField] private Counting _counting;
    private bool count = false;
    public string ItemName => itemName;
    void Start()
    {
        if (lv3)
        {
            _end = Counter.GetComponent<ToTheEnd>();
        }
        myLight = GetComponentInChildren<Light>(includeInactive: true);
        myParticleSystem = GetComponentInChildren<ParticleSystem>(includeInactive: true);
        if (Off)
        {
            myParticleSystem.Stop();
            myParticleSystem.Clear();
            myLight.enabled = false;
        }   _switch = GetComponent<AudioSource>();
        _counting = Counter.GetComponent<Counting>();
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
            _switch.Play();
        }

        if (!count && !lv3) 
        {
            _counting.actCandle++;
            count = true;
        }
        else if (!count && lv3) 
        {
            _end.LeCount++;
            count = true;
        }
    }
}
