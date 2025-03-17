using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void UpdateScore(int score)
    {
        scoreText.text = "Puntos: " + score;
    }
    public void UpdateHealth(int health)
    {
        healthText.text = "Vida: " + health;
    }
}
