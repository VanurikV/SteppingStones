using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayScript : MonoBehaviour
{
    public AudioClip[] SoundPlayClip;

    private AudioSource audioSource;


    public void PlayRandomTrack()
    {
        audioSource.Stop();
        audioSource.clip = SoundPlayClip[Random.Range(0, SoundPlayClip.Length)];
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StopPlay()
    {
        audioSource.Stop();
    }


    
    public void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
}
