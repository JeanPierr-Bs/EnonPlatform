using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    public TextMeshProUGUI scoreText; // Texto de la puntuación
    public TextMeshProUGUI healthText; // Texto de las vidas

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
    public void UpdateHealth(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Vidas: " + currentHealth;
        }
    }
}
