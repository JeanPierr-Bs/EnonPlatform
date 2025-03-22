using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource[] music;
    public AudioSource[] sfx;

    public AudioMixerGroup musicMixer, SfxMixer;

    private int currentMusicIndex = -1; // Para recordar qué música estaba sonando

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        if (currentMusicIndex == -1) // Solo inicia si no había música sonando antes
        {
            PlayMusic(0);
        }
    }

    public void PlayMusic(int musicToPlay)
    {
        if (musicToPlay < 0 || musicToPlay >= music.Length)
        {
            Debug.LogWarning("Índice de música fuera de rango: " + musicToPlay);
            return;
        }

        if (currentMusicIndex == musicToPlay && music[musicToPlay].isPlaying)
            return; // Evita que la misma música se vuelva a reproducir al reiniciar

        StopAllMusic(); // Asegura que no haya duplicados
        music[musicToPlay].Play();
        currentMusicIndex = musicToPlay;
    }

    public void StopAllMusic()
    {
        foreach (var m in music)
        {
            if (m.isPlaying)
                m.Stop();
        }
        currentMusicIndex = -1;
    }

    public void PlaySfx(int sfxToPlay)
    {
        if (sfxToPlay < 0 || sfxToPlay >= sfx.Length)
        {
            Debug.LogWarning("Índice de SFX fuera de rango: " + sfxToPlay);
            return;
        }

        sfx[sfxToPlay].Play();
    }

    public void ResetAudio()
    {
        StopAllSfx();
        PlayMusic(currentMusicIndex); // Reproduce la música que estaba sonando antes
    }

    public void StopAllSfx()
    {
        foreach (var s in sfx)
        {
            if (s.isPlaying)
                s.Stop();
        }
    }
    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", PauseMenu.instance.musicSlider.value);
    }
    public void SetSFXLevel()
    {
        SfxMixer.audioMixer.SetFloat("SfxVolume",PauseMenu.instance.sfxSlider.value);
    }
}
