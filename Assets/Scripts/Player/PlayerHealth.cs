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
    // private Collider col; // Referencia al Collider
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLives = maxLives; //inicia con todas las vidas
        Debug.Log("Tus vidas son:" + currentLives);
        UiManager.Instance.UpdateHealth(currentLives);
    }

    public void TakeDamage()
    {
        currentLives--; //Resta una vida
        UiManager.Instance.UpdateHealth(currentLives);
        Debug.Log("Vidas restantes: " + currentLives);

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
        Debug.Log("Vida recuperada. Vida actual: " + currentLives);
    }
    private void GameOver()
    {
        Debug.Log("¡Game Over! Reiniciando nivel...");
        UiManager.Instance.ShowGameOver();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
    }
}
