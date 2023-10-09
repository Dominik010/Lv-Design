using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour, Interactive
{
    public GameObject Door;
    [SerializeField] float Distance = 5f;
    bool interacted;
    public void Interact()
    {
        if (!interacted)
        {
            Door.transform.position += Vector3.up * Distance;
            interacted = true;
        }

    }
}
