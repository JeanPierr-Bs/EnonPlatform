using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    public Transform[] waypoints; // Puntos entre los que se mover�
    public float moveSpeed = 3f;
    public float rotationSpeed = 300f; // Velocidad de rotaci�n
    private int nextWaypoint = 0;

    private void Update()
    {
        MoveSaw();
        RotateSaw();
    }
    void MoveSaw()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, waypoints[nextWaypoint].position) < 0.1f)
        {
            nextWaypoint++;
            if (nextWaypoint >= waypoints.Length)
                nextWaypoint = 0;
        }
    }
    void RotateSaw()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador fue da�ado por la sierra!");
            PlayerHealth.Instance.TakeDamage(); // Ajusta seg�n tu sistema de vida
        }
    }
}
