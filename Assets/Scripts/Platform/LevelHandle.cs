using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandle : MonoBehaviour
{
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            MovingPlatform[] platforms = FindObjectsOfType<MovingPlatform>();

            foreach (MovingPlatform platform in platforms)
            {
                platform.Activate();
            }

            Debug.Log("Plataformas activadas por la palanca.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Estas en zona");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
