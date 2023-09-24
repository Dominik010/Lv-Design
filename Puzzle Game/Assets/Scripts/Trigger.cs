using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, Interactive
{
    public GameObject Door;
    public void Interact()
    {
        Door.SetActive(false);
    }
}
