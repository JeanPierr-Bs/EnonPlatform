using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public Animator buttonAnimator; // Asigna el Animator del botón
    public float bounceForce = 10f; // Fuerza del rebote
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonAnimator.ResetTrigger("Rise"); // Resetea el Trigger (importante)
            buttonAnimator.SetTrigger("Rise"); // Vuelve a activarlo

            // Hacer que el jugador rebote
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Bounce(bounceForce);
            }
        }
    }
}
