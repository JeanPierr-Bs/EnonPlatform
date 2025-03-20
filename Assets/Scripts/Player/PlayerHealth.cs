using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3; // Numero de vidas del jugador
    private int currentLives;
    // private Collider col; // Referencia al Collider

    private void Start()
    {
        currentLives = maxLives; //inicia con todas las vidas
        Debug.Log("Tus vidas son:" + currentLives);
    }

    public void TakeDamage()
    {
        currentLives--; //Resta una vida
        Debug.Log("Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Debug.Log("¡Game Over! Reiniciando nivel...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
    }
}
