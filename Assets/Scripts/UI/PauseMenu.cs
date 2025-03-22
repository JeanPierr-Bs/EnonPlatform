using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public GameObject pausePanel, optionPanel; // Panel de pausa
    public Slider musicSlider, sfxSlider;
    private bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Detecta ESC
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Detiene todo
        isPaused = true;
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true;
    }
    public void OpenOptionPanel()
    {
        optionPanel.SetActive(true);
    }

    public void CloseOptionPanel()
    {
        optionPanel.SetActive(false);
    }
    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Reactiva el juego
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Time.timeScale = 1f; // Asegura que el tiempo vuelva a la normalidad
        SceneManager.LoadScene("MainMenu"); // Vuelve al menú principal
    }
    public void SetMusicLevel()
    {
        SoundManager.instance.SetMusicLevel();
    }
    public void SetSFXLevel()
    {
        SoundManager.instance.SetSFXLevel();
    }
}
