using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            CharacterController characterController = other.GetComponent<CharacterController>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // Resta una vida
            }
            if (characterController != null)
            {
                // Desactiva el CharacterController antes de mover al jugador
                characterController.enabled = false;

                // Verifica si hay un checkpoint guardado, si no, usa la posici�n inicial
                Vector3 respawnPosition = (SpawnManager.lastCheckPointPosition != Vector3.zero)
                    ? SpawnManager.lastCheckPointPosition
                    : Vector3.zero;

                other.transform.position = respawnPosition; // Mueve al jugador al checkpoint

                // Reactiva el CharacterController despu�s de moverlo
                characterController.enabled = true;

                //Debug.Log("Jugador muri�. Respawn en: " + respawnPosition);
            }
            else
            {
                //Debug.LogError("El jugador no tiene CharacterController asignado.");
            }
        }
    }
}

