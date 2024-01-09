using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HebelSchalter : MonoBehaviour, Interactive
{
    [SerializeField] private Animator dAnimator;
    private Animator lAnimator;

    [SerializeField] private string itemName;
    public string ItemName => itemName;
    void Start()
    {
        lAnimator = GetComponent<Animator>();
    }

    public void Interact()
    {
        lAnimator.SetTrigger("Trigger");
    }
    private void Open()
    {
        dAnimator.SetTrigger("_lever");
    }
}
