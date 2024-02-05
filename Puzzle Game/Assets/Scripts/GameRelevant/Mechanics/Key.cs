using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactive
{
    public GameObject Lock;
    private FadeBlack Fader;
    private CheckForDynamite TheyGotIt;
    [SerializeField] private AudioSource getKeys;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    void Start()
    {
        Fader = Lock.GetComponent<FadeBlack>();
        getKeys = GetComponent<AudioSource>();
        TheyGotIt = Lock.GetComponent<CheckForDynamite>();
    }

    public void Interact()
    {
        if (Fader != null)
        Fader.gotKey = true;
        else if (TheyGotIt != null)
        TheyGotIt.keyItem2 = true;
        StartCoroutine(KeyIsMine());
    }

    private IEnumerator KeyIsMine()
    {
        getKeys.Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
