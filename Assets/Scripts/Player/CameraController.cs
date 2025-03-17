using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 100f;
    public float rotationLimit = 80f;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Oculta el cursor solo al inicio
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical con límite
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -rotationLimit, rotationLimit);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal y sincronización con el jugador
        player.Rotate(Vector3.up * mouseX);
    }

    public Vector3 GetCameraForward()
    {
        Vector3 forward = transform.forward;
        forward.y = 0; // Evita inclinaciones
        return forward.normalized;
    }
}
