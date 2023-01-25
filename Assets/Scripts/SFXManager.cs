using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    public static SFXManager sharedInstance;

    private AudioSource source;

    private void Awake()
    {
        if (!sharedInstance)
        {
            sharedInstance = this;
            source = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void PlaySound(AudioClip clip, bool isLooped = true)
    {
        source.clip = clip;
        source.loop = isLooped;
        source.Play();
    }

}
