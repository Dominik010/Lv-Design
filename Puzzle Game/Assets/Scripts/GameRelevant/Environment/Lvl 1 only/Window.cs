using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private AudioSource wSource;
    private bool OneAndDone;

    private void Awake()
    {
        wSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stone") && !OneAndDone)
        {
            OneAndDone = false;
            StartCoroutine(Broken());
        }
    }

    private IEnumerator Broken()
    {
        wSource.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
