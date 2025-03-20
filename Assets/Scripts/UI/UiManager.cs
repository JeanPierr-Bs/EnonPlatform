using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    public TextMeshProUGUI scoreText; // Texto de la puntuación
    public TextMeshProUGUI healthText; // Texto de las vidas
    public GameObject gameOverPanel;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        Time.timeScale = 1; // Asegurar que el juego NO inicie pausado
    }

    // Actualiza el texto de la puntuación
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntos: " + score;
        }
    }

    // Actualiza el texto de las vidas
    public void UpdateHealth(int currentLives)
    {
        if (healthText != null)
        {
            healthText.text = "Vidas: " + currentLives;
        }
    }
    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0; // Pausa el 
            gameOverPanel.SetActive(true); //Muestra la pantalla de Game Over
        }
    }
    public void Retry()
    {
        Time.timeScale = 1; // Restaura el tiempo antes de reiniciar
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        ScoreManager.Instance.ResetScore();
    }
    public void ExitToMainMenu()
    {
        Destroy(gameObject);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
