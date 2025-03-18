using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Panel de pausa
    private bool isPaused = false;
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
}
