using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager sharedInstance;

    private AudioSource source;

    private bool ignoreMusicTail;

    private List<AudioClip> musicTail;
    private float wait;
    private bool check;

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

    private void Start()
    {
        musicTail = new List<AudioClip>();
    }

    private void Update()
    {
        if (check)
        {
            wait -= Time.deltaTime;
        }

        if (wait < 0f && !ignoreMusicTail)
        {
            if (musicTail.Count > 0)
            {
                AudioClip clip = musicTail[0];
                PlayMusic(clip);
                musicTail.RemoveAt(0);
            }

            check = false;
        }
    }

    public void PlayMusic(AudioClip clip, bool isLooped = false)
    {
        ignoreMusicTail = isLooped;

        source.Stop();
        source.clip = clip;
        source.loop = isLooped;

        wait = clip.length;

        check = true;

        source.Play();
    }

    public void AddToTail(AudioClip clip)
    {
        musicTail.Add(clip);
    }
}
