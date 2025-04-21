using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] target;
    public float speed = 6f;
    public bool isActive = false;

    private Renderer rend;
    private Collider col;

    int curPos = 0;
    int nextPos = 1;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();

        if (!isActive)
        {
            if (rend != null) rend.enabled = false;
            if (col != null) col.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        
        transform.position = Vector3.MoveTowards(transform.position, target[nextPos].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target[nextPos].position) <= 0)
        {
            curPos = nextPos;
            nextPos++;
            if(nextPos > target.Length - 1)
                nextPos = 0;
        }
    }
    public void Activate()
    {
        isActive = true;

        if (rend != null) rend.enabled = true;
        if (col != null) col.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform); // Hacer que el jugador sea hijo de la plataforma
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null); // Liberar al jugador cuando salga de la plataforma
        }
    }
}
