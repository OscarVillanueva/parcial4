using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandleController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Canvas[] interactIndicators;

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
        animator.SetBool("isOpening", false);
        ToogleCanvas(false);
        GameManager.OnPlayerInteractions -= OpenDoor;
    }

    private void OpenDoor()
    {
        animator.SetBool("isOpening", true);
        ToogleCanvas(false);
    }

    private void ToogleCanvas(bool isShowing)
    {
        foreach(Canvas canvas in interactIndicators)
        {
            canvas.enabled = isShowing;
        }
    }
}
