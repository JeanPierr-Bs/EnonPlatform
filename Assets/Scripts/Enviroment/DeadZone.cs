using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador cayó en la DeathZone.");
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.maxHealth); // Matar instantáneamente
            }
            // Desactivar jugador antes de reaparecerlo
            other.gameObject.SetActive(false);
            SpawnManager.instance.RespawnPlayer(other.gameObject);
        }
    }
}

