using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healAmount = 20; // Cantidad de vida que restaura
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador lo toca
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Cura al jugador
                Destroy(gameObject); // Elimina el objeto tras usarlo
            }
        }
    }
}
