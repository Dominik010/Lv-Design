using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextRay : MonoBehaviour
{
    public TextMeshProUGUI displayedText;
    public LayerMask layerMask;
    public float iDistance = 2;
    public float timeCheck = 0.2f;
    private float Timer;

    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= timeCheck)
        {
            Timer = 0;
            CheckInteraction();
        }
    }

    private void CheckInteraction()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, iDistance, layerMask))
        {
            if (hit.collider.gameObject.TryGetComponent(out Interactive interactive))
            {
                ShowText(hit.collider.gameObject.name);
            }              
        }
        else
        {
            StopText();
        }
    }

    private void ShowText(string name)
    {
        displayedText.text = "[E] interact with " + name;
        displayedText.gameObject.SetActive(true);
    }

    private void StopText()
    {
        if (displayedText != null)
        {
            displayedText.gameObject.SetActive(false);
        }
    }
}
