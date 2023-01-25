using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubHandlerController : MonoBehaviour
{
    [SerializeField] private Canvas interactIndicator;
    [SerializeField] private Animator animator;

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
            GameManager.OnPlayerInteractions += RollTub;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !isAlreadyOpen)
        {
            interactIndicator.enabled = false;
            GameManager.OnPlayerInteractions -= RollTub;
        }
    }

    private void RollTub()
    {
        animator.SetBool("isRolling", true);

        isAlreadyOpen = true;
        interactIndicator.enabled = false;
        GameManager.OnPlayerInteractions -= RollTub;
    }
}
