using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceHandleController : MonoBehaviour
{
    [Header("Interactions")]
    [SerializeField] private Canvas interactIndicator;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip exitClip;

    private bool isAlreadyOpen;

    private void Start()
    {
        isAlreadyOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAlreadyOpen)
        {
            interactIndicator.enabled = true;
            GameManager.OnPlayerInteractions += RollEntrance;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isAlreadyOpen)
        {
            interactIndicator.enabled = false;
            GameManager.OnPlayerInteractions -= RollEntrance;
        }
    }

    private void RollEntrance()
    {
        animator.SetBool("isRolling", true);

        SFXManager.sharedInstance.PlayAtPosition(exitClip, transform.position);

        isAlreadyOpen = true;
        interactIndicator.enabled = false;

        GameManager.OnPlayerInteractions -= RollEntrance;
    }

    public void FinishGame()
    {
        UIManager.sharedInstance.FinishGame();
    }
}
