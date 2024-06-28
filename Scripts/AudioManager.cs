using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-----Audio Clips-----")]
    public AudioClip background;
    public AudioClip generalTheme;
    public AudioClip bossTheme;

    [Header("interacts")]
    public AudioClip interact;
    public AudioClip panels;
    public AudioClip elevator;
    public AudioClip door;
    public AudioClip engine;
    public AudioClip errorInteract;

    [Header("enemies")]
    public AudioClip spawner;
    public AudioClip zombieNoise;
    public AudioClip zombieAttack;
    public AudioClip zombieRage;

    [Header("player")]
    public AudioClip gun;
    public AudioClip death;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
