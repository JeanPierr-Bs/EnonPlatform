using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    private Vector3 currentSpawnPoint;
    private List<LoosePlatform> fallingPlatforms = new List<LoosePlatform>();//Lista de plataformas

    void Awake()    
    {
        instance = this;
        currentSpawnPoint = transform.position;
    }
    private void Start()
    {
        SpawnPoint[] points = FindObjectsOfType<SpawnPoint>();
        if (points.Length > 0)
        {
            currentSpawnPoint = points[0].transform.position; // Punto inicial
        }
        // Encontrar todas las plataformas al inicio
        LoosePlatform[] platforms = FindObjectsOfType<LoosePlatform>();
        fallingPlatforms.AddRange(platforms);
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        if (instance != null)
        {
            instance.currentSpawnPoint = newSpawnPoint;
            Debug.Log("Nuevo SpawnPoint guardado: " + newSpawnPoint);
        }
    }

    public void RespawnPlayer(GameObject player)
    {
        if (instance != null)
        {
            Debug.Log("Respawneando en: " + instance.currentSpawnPoint);
            player.transform.position = instance.currentSpawnPoint;
            player.SetActive(true);

            // Reiniciar la velocidad si es necesario
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                controller.enabled = true;
            }
            // Restaurar plataformas caídas
            ResetPlatforms();
        }
    }
    private void ResetPlatforms()
    {
        foreach (LoosePlatform platform in fallingPlatforms)
        {
            platform.ResetPlatform(); // Reactiva y posiciona correctamente las plataformas
        }
        Debug.Log("Plataformas reiniciadas.");
    }
}
