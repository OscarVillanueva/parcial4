using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientController : MonoBehaviour
{
    [SerializeField] private AudioClip ambientClip;
    [SerializeField] private bool playAtStart = true;

    private bool alreadyPlay = false;

    private void Start()
    {
        if (playAtStart)
            SFXManager.sharedInstance.PlaySound(ambientClip);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playAtStart && other.CompareTag("Player") && !alreadyPlay)
        {
            SFXManager.sharedInstance.PlaySound(ambientClip);
            alreadyPlay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        alreadyPlay = false;
    }
}
