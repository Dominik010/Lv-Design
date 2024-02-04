using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counting : MonoBehaviour
{
    public int actCandle = 0;
    private Animator sAnim;
    private AudioSource sSource;
    [SerializeField] private GameObject Ship;
    private AudioSource sAudio;

    private void Start()
    {
        sAnim = GetComponent<Animator>();
        sSource = GetComponent<AudioSource>();
        sAudio = Ship.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (actCandle == 5)
        {
            sSource.Play();
            sAudio.Play();
            SummonShip();
            actCandle++;
        }
    }

    void SummonShip()
    {
        sAnim.SetTrigger("Candler");
    }
}
