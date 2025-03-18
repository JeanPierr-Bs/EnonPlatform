using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class LoosePlatform : MonoBehaviour
{
    private float WaitToFall = 0.4f;
    private float WaitToDestroy = 1f;
    private Rigidbody rb;
    private Collider col; // Referencia al Collider
    private Vector3 startPosition;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>(); // Obtener el Collider
        startPosition = transform.position;
        // Asegurar que la f�sica de la plataforma est� activada
        rb.isKinematic = true;
        rb.useGravity = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El jugador activ� la plataforma: " + gameObject.name);
            StartCoroutine(Drop());
        }
    }
    private IEnumerator Drop()
    {
        yield return new WaitForSeconds(WaitToFall);
        col.enabled = false; // Desactiva la colisi�n antes de caer
        rb.isKinematic = false;
        rb.useGravity = true; // Activa la gravedad\
        rb.WakeUp();
        yield return new WaitForSeconds(WaitToDestroy);
        gameObject.SetActive(false); // Desactiva la plataforma en lugar de destruirla
    }
    // M�todo para resetear la plataforma (llamarlo desde SpawnManager cuando el player muera)
    public void ResetPlatform()
    {
        Debug.Log("Reseteando plataforma: " + gameObject.name);
        StopAllCoroutines();
        gameObject.SetActive(true);
        transform.position = startPosition; // Restaura la posici�n inicial
        rb.useGravity = false;
        rb.velocity = Vector3.zero; // Detiene cualquier movimiento
        col.enabled = true;
        rb.isKinematic = true;
    }
}
