using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandle : MonoBehaviour
{
    [Header("Torque Settings")]
    public float activationAngle = 45f;       // Ángulo mínimo para activarse
    public HingeJoint leverJoint;             // Referencia al HingeJoint (palanca)
    public float torqueThreshold = 1f;        // Valor mínimo de torque requerido (opcional para ajustes)

    [Header("Palanca Config")]
    public Transform playerDetector;          // Zona donde el jugador puede activar con E si querés usar input
    public string collisionTag = "CollisionLevel"; // Tag para detectar objetos que pueden activar la palanca
    private bool activated = false;           // Evita múltiples activaciones
    private bool playerInZone = false;        // Saber si el jugador está en la zona
    public Animator leverAnimator;             // Referencia al Animator de la palanca

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (leverJoint == null)
        {
            leverJoint = GetComponent<HingeJoint>();
        }
    }
    void Update()
    {
        if (activated) return;

        float currentAngle = leverJoint.angle;

        if (Mathf.Abs(currentAngle) >= activationAngle)
        {
            Activate();
        }

        // Activación manual con "E" si el jugador está cerca
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("🔧 Activación manual con tecla E.");
            Activate();
        }
    }
    private void Activate()
    {
        if (activated) return;

        activated = true;

        MovingPlatform[] platforms = FindObjectsOfType<MovingPlatform>();
        foreach (MovingPlatform platform in platforms)
        {
            platform.Activate();
        }
        // Ejecutar animación de la palanca
        if (leverAnimator != null)
        {
            leverAnimator.SetBool("ActivateLever", true);  // Asegúrate de que tienes este trigger en tu Animator
        }

        Debug.Log("✅ Palanca activada. Plataformas en movimiento.");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            Debug.Log("👣 Jugador en zona de activación.");
        }

        if (other.CompareTag(collisionTag))
        {
            Debug.Log("💥 Colisión detectada con objeto de tag " + collisionTag);
            Activate();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            Debug.Log("🚪 Jugador salió de la zona.");
        }
    }
}
