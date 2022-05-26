using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip;
    public bool loop = true;

    AudioSource audioSource;

    private void Start()
    {
        if(musicClip != null)
        {
            audioSource = AudioManager.audioInstance.GetMusicSource();
            audioSource.clip = musicClip;
            audioSource.loop = loop;
            audioSource.Play();
        }
    }
}
