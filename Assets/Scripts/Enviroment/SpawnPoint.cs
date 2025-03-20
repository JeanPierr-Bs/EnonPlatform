using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.lastCheckPointPosition = transform.position;
            Debug.Log("La posicion del checkpoint se guardo");
        }
    }
}
