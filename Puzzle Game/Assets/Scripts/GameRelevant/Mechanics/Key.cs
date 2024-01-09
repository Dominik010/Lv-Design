using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactive
{
    public GameObject Lock;
    private FadeBlack Fader;
    [SerializeField] private AudioSource getKeys;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    void Start()
    {
        Fader = Lock.GetComponent<FadeBlack>();
        getKeys = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        getKeys.Play();
        Fader.gotKey = true;
        gameObject.SetActive(false);
    }
}
