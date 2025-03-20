using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;  // Música de fondo
    [SerializeField] private AudioSource sfxSource;    // Fuente de efectos de sonido

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;    // Referencia al Audio Mixer

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene el sonido al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Reproduce una música de fondo
    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource.clip != musicClip)
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }
    }

    // Reproduce un efecto de sonido
    public void PlaySFX(AudioClip sfxClip)
    {
        sfxSource.PlayOneShot(sfxClip);
    }

    // Cambia el volumen de la música (Usado en el menú de opciones)
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20); // Convierte lineal a dB
    }

    // Cambia el volumen de los efectos de sonido
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
