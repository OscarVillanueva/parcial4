using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FallingShelf : MonoBehaviour
{
    [SerializeField] private AudioClip sound;

    private Animator animator;

    private void Start()
    {
        GameManager.OnThingsMoving += Fall;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Fall()
    {
        animator.SetBool("isFalling", true);
        GameManager.OnThingsMoving -= Fall;
    }

    public void PlaySound()
    {
        SFXManager.sharedInstance.PlayAtPosition(sound, transform.position);
    }
}
