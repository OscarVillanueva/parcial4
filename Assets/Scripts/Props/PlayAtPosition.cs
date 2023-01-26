using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayAtPosition : MonoBehaviour
{
    [SerializeField] private AudioClip clip2Play;
    private bool alreadyPlay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyPlay)
        {
            SFXManager.sharedInstance.PlayAtPosition(clip2Play, transform.position);
            alreadyPlay = true;
        }
    }
}
