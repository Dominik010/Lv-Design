using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private TextMeshProUGUI tText;
    [SerializeField] private string areaText;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tText.text = areaText;
            Panel.SetActive(true);
            tText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(false);
            tText.gameObject.SetActive(false);
        }
    }
}
