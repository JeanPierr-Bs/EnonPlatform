using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 10; // Valor de la moneda
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador la toca
        {
            ScoreManager.Instance.AddPoints(points); // Suma los puntos
            Destroy(gameObject); // Destruye la moneda
        }
    }
}
