using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBlack : MonoBehaviour, Interactive
{
    [SerializeField] private Animator _Animator;
    private readonly int fadeOut = Animator.StringToHash("FadeOut");
    private readonly int runTime = Animator.StringToHash("Speed");
    [SerializeField] private Transform newTransform;
    public GameObject Player;
    public bool gotKey;
    private bool portPlayer;
    private PlayerMovement pM;

    void Start () 
    {
        pM = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (portPlayer)
        {
            pM.enabled = false;
        }
        else if (!portPlayer)
        {
            pM.enabled = true;
        }
    }
    public void Interact()
    {
        if (gotKey) 
        {
            Debug.Log("Fading");
            portPlayer = true;
            StartCoroutine(Fading());
        }
    }

    public IEnumerator Fading()
    {
        _Animator.SetFloat(runTime, 1f);
        _Animator.SetTrigger(fadeOut);
        yield return new WaitForSeconds(1f);
        Player.transform.position = newTransform.position;
        yield return new WaitForSeconds(1f);
        Debug.Log("Unfading");
        _Animator.SetFloat(runTime, -1f);
        _Animator.SetTrigger(fadeOut);
        portPlayer = false;
    }
}
