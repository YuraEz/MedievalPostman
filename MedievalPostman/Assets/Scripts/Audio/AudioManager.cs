using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource defaultSource;

    private void OnEnable()
    {
        ServiceLocator.AddService(this);
    }

    private void OnDisable()
    {
        ServiceLocator.RemoveService(this);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        defaultSource.clip = clip;
        defaultSource.Play();
    }
}
