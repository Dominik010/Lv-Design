using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeBlack : MonoBehaviour, Interactive
{
    [SerializeField] private Animator _Animator;
    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int runTime = Animator.StringToHash("Speed");
    [SerializeField] private Transform newTransform;
    public GameObject Player;
    public GameObject Level1;
    public GameObject Level2;
    public bool gotKey;
    private bool portPlayer;
    private bool isPlaying;
    private PlayerMovement pM;
    private Rigidbody Prb;
    public AudioSource locked;
    [SerializeField] private GameObject hText;

    [SerializeField] private string itemName;
    public string ItemName => itemName;

    void Start () 
    {
        pM = Player.GetComponent<PlayerMovement>();
        Prb = Player.GetComponent<Rigidbody>();
        locked = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (portPlayer)
        {
            pM.enabled = false;
            Prb.isKinematic = true;
        }
        else if (!portPlayer)
        {
            pM.enabled = true;
            Prb.isKinematic = false;
        }
    }
    public void Interact()
    {
        if (gotKey) 
        {
            Level2.SetActive(true);
            portPlayer = true;
            // StartCoroutine(Fading());
            _Animator.SetTrigger(fadeOut);
            StartCoroutine(WaitForAnimation("Fade_Out", 0, () =>
            {
                Player.transform.position = newTransform.position;
                Debug.Log("Teleport");
                portPlayer = false;
            }));
        }
        else if (!gotKey && !isPlaying)
        {
            isPlaying = true;
            StartCoroutine(ShowText());
        }
    }

    public IEnumerator Fading()
    {
        _Animator.SetFloat(runTime, 1f);
        _Animator.SetTrigger(fadeOut);
        yield return new WaitForSeconds(1f);
        Player.transform.position = newTransform.position;
        yield return new WaitForSeconds(1f);
        portPlayer = false;
    }

    IEnumerator WaitForAnimation(string animationNameInAnimator, int animationlayerIndex, Action callback)
    {
        yield return new WaitUntil(() => _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        yield return new WaitUntil(() => _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).normalizedTime > 0.95f 
        && _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        callback?.Invoke();
        pM.enabled = true;
        Prb.isKinematic = false;
        Level1.SetActive(false);
    }

    private IEnumerator ShowText()
    {
        locked.Play();
        hText.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        hText.SetActive(false);
        isPlaying = false;
    }
}
