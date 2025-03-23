using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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
            transform.parent = null; // Asegura que sea un objeto raíz
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded; // Detectar cambio de escena
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        ChangeMusicByScene(SceneManager.GetActiveScene().name); // Verifica qué música debe sonar
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusicByScene(scene.name); // Cambia la música cuando cambia de escena
    }
    public void PlayMusic(int musicToPlay)
    {
        if (musicToPlay < 0 || musicToPlay >= music.Length)
        {
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
            return;
        }

        sfx[sfxToPlay].Play();
    }
    public void StopAllSfx()
    {
        foreach (var s in sfx)
        {
            if (s.isPlaying)
                s.Stop();
        }
    }
    public void ResetAudio()
    {
        StopAllSfx();
        PlayMusic(currentMusicIndex); // Reproduce la música que estaba sonando antes
    }
    public void SetMusicLevel(float volume)
    {
        musicMixer.audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetSFXLevel(float volume)
    {
        SfxMixer.audioMixer.SetFloat("SfxVolume",volume);
    }
    // Cambia la música según la escena
    private void ChangeMusicByScene(string sceneName)
    {
        if (sceneName == "MainMenu")
        {
            PlayMusic(1); // Música del menú
        }
        else if (sceneName == "EnonPlatform")
        {
            PlayMusic(0); // Música del nivel
        }
    }
}
