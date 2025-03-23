using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }
    public int maxLives = 3; // Numero de vidas del jugador
    private int currentLives;
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

    private void Start()
    {
        currentLives = maxLives; //inicia con todas las vidas
        UiManager.Instance.UpdateHealth(currentLives);
    }

    public void TakeDamage()
    {
        currentLives--; //Resta una vida
        UiManager.Instance.UpdateHealth(currentLives);
        ResetPlatforms();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    public void Heal(int amount)
    {
        currentLives += amount;
        currentLives = Mathf.Clamp(currentLives, 0, maxLives); // Evita que pase el máximo
        UiManager.Instance.UpdateHealth(currentLives); // Actualiza la UI
    }
    private void ResetPlatforms()
    {
        LoosePlatform[] platforms = FindObjectsOfType<LoosePlatform>(); // Encuentra todas las plataformas

        foreach (LoosePlatform platform in platforms)
        {
            platform.ResetPlatform(); // Reinicia cada plataforma
        }
    }
    private void GameOver()
    {
        UiManager.Instance.ShowGameOver();
    }
}
