using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Timinger;
    public float Timering = 0;
    void Update()
    {
        Timering = Time.deltaTime;
        Timinger.text = new string (Timinger.text + Timering);
    }
}
