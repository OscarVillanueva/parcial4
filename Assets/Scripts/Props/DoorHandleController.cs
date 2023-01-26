using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleController : MonoBehaviour
{
    [Header("Interactions")]
    [SerializeField] private Canvas[] interactIndicators;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioClip closeDoorClip;
    private bool wasOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToogleCanvas(true);
            GameManager.OnPlayerInteractions += OpenDoor;        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(CloseDoor), 1.0f);
        }
    }

    private void CloseDoor()
    {
        if (wasOpen)
        {
            wasOpen = false;
            SFXManager.sharedInstance.PlaySound(closeDoorClip, false);
            animator.SetBool("isOpening", false);
        }

        ToogleCanvas(false);
        GameManager.OnPlayerInteractions -= OpenDoor;
    }

    private void OpenDoor()
    {
        SFXManager.sharedInstance.PlaySound(openDoorClip, false);
        animator.SetBool("isOpening", true);
        ToogleCanvas(false);
        wasOpen = true;
    }

    private void ToogleCanvas(bool isShowing)
    {
        foreach(Canvas canvas in interactIndicators)
        {
            canvas.enabled = isShowing;
        }
    }
}
