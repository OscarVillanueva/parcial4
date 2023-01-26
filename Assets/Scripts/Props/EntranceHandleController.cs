using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceHandleController : MonoBehaviour
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

        isAlreadyOpen = true;
        interactIndicator.enabled = false;

        GameManager.OnPlayerInteractions -= RollEntrance;
    }
}
