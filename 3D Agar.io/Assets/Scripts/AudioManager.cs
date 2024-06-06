using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Sources---------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("--------Audio Clips---------")]
    public AudioClip Background;
    public AudioClip Collect;
    public AudioClip Gameover;

    public void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

}
