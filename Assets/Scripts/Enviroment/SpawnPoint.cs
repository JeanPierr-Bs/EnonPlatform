using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private bool isActive = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
            if (spawnManager != null)
            {
                spawnManager.SetSpawnPoint(transform.position);
            }

            isActive = true;
            Debug.Log("Nuevo SpawnPoint activado en: " + transform.position);
        }
    }
}
