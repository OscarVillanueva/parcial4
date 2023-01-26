using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskHandleController : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private Canvas interactIndicator;

    [Header("Animations")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip openClip;

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
            GameManager.OnPlayerInteractions += OpenDesk;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isAlreadyOpen)
        {
            interactIndicator.enabled = false;
            GameManager.OnPlayerInteractions -= OpenDesk;
        }
    }

    private void OpenDesk()
    {
        animator.SetBool("isOpened", true);

        SFXManager.sharedInstance.PlayAtPosition(openClip, transform.position);

        isAlreadyOpen = true;
        interactIndicator.enabled = false;
        GameManager.OnPlayerInteractions -= OpenDesk;
    }
}
