using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CheckForDynamite : MonoBehaviour, Interactive
{
    [SerializeField] private GameObject Ltext;
    [SerializeField] private string itemName;
    public string ItemName => itemName;

    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int runTime = Animator.StringToHash("Speed");
    private PlayerMovement pM;
    private Rigidbody Prb;
    public GameObject Player;
    [SerializeField] private AudioSource Kaboom;

    private bool keyItem1;
    public bool keyItem2;

    private bool isPlaying;
    [SerializeField] private Animator _anim;

    void Start()
    {
        pM = Player.GetComponent<PlayerMovement>();
        Prb = Player.GetComponent<Rigidbody>();
        Kaboom = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dynamite"))
        {
            keyItem1 = true;
        }
    }

    public void Interact()
    {
        if(!isPlaying && !keyItem1 || !isPlaying && !keyItem2)
        {
            StartCoroutine(ShowText());
        }
        else if (keyItem1 && keyItem1)
        {
            pM.enabled = false;
            Prb.isKinematic = true;
            Kaboom.Play();
            _anim.SetTrigger(fadeOut);
            StartCoroutine(WaitForAnimation("Fade_Out", 0, () =>
            {
                Debug.Log("Destroy");
                gameObject.SetActive(false);
            }));
        }
    }

    IEnumerator ShowText()
    {
        Ltext.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        Ltext.SetActive(false);
        isPlaying = false;
    }
    IEnumerator WaitForAnimation(string animationNameInAnimator, int animationlayerIndex, Action callback)
    {
        yield return new WaitUntil(() => _anim.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        yield return new WaitUntil(() => _anim.GetCurrentAnimatorStateInfo(animationlayerIndex).normalizedTime > 0.95f
        && _anim.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        callback?.Invoke();
        pM.enabled = true;
        Prb.isKinematic = false;
    }
}
