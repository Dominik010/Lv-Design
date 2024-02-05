using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private Animator _Animator;
    private readonly int fade = Animator.StringToHash("FadeOut");
    private PlayerMovement pM;
    private Rigidbody Prb;
    public GameObject Player;

    void Start()
    {
        pM = Player.GetComponent<PlayerMovement>();
        Prb = Player.GetComponent<Rigidbody>();
    }

        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _Animator.SetTrigger(fade);
            pM.enabled = false;
            Prb.isKinematic = true;
            StartCoroutine(WaitForAnimation("New_State", 0, () =>
            {
                SceneManager.LoadScene("Menu 2");
            }));
        }
    }
    IEnumerator WaitForAnimation(string animationNameInAnimator, int animationlayerIndex, Action callback)
    {
        yield return new WaitUntil(() => _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        yield return new WaitUntil(() => _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).normalizedTime > 0.95f
        && _Animator.GetCurrentAnimatorStateInfo(animationlayerIndex).IsName(animationNameInAnimator));
        callback?.Invoke();
    }
}
