using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuDisabler : MonoBehaviour
{
    [SerializeField] private GameObject[] Tutorials;
    [SerializeField] private GameObject tutorialText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject Tutorials in Tutorials)
            {
                Tutorials.SetActive(false);
            }
        }
        tutorialText.SetActive(false); ;
    }
}
