using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FallingShelf : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    private Animator animator;

    // TODO: Regitrastar la funcion de caer en el mager

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Fall()
    {
        animator.SetBool("isFalling", true);
    }

    public void PlaySound()
    {
        SFXManager.sharedInstance.PlayAtPosition(sound, transform.position);
    }
}
