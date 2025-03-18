using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    public float jumpHeight = 2f;
    private float coyoteTime = 0.2f; // Tiempo extra para saltar
    private float coyoteTimeCounter;
    private float climbSpeed = 2f;
    private bool canDoubleJump = true;
    private bool isClimbing = false;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private Animator anim;
    public CharacterController charController;
    private Camera playerCamera;
    void Awake()
    {
        instance = this;
        charController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        playerCamera = Camera.main;
    }
    void Update()
    {
        HandleMove();
        HandleJump();
        if (charController.isGrounded)
        {
            anim.SetBool("isJumping", false);
        }
    }
    private void HandleMove()
    {
        bool isMoving = Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
        anim.SetBool("isMoving", isMoving); // Activa la animación de caminar

        if (isClimbing)
        {
            moveDirection.y = Input.GetAxisRaw("Vertical") * climbSpeed; // Movimiento vertical en la escalera
            moveDirection.x = Input.GetAxisRaw("Horizontal") * moveSpeed; // Movimiento lateral opcional
            moveDirection.z = 0f; // Evitar movimientos no deseados

            charController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            Vector3 moveDir = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection.x = moveDir.x * moveSpeed;
            moveDirection.z = moveDir.z * moveSpeed;
            Cursor.lockState = CursorLockMode.Locked;//Bloquea el mouse
            Cursor.visible = false;

            charController.Move(moveDirection * Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
        }
    }
    private void HandleJump()
    {
        if (isClimbing)
        {
            if (Input.GetButtonDown("Jump"))
            {
                isClimbing = false; // Salimos del estado de escalada
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y); // Salto al soltar escalera
                anim.SetBool("isJumping", true); // Activa la animación de salt
            }
        }
        if (charController.isGrounded)
        {
            if (moveDirection.y < 0) // Solo resetea cuando el jugador realmente aterriza
            {
                coyoteTimeCounter = coyoteTime; // Resetea el tiempo cuando está en el suelo
                canDoubleJump = true;
            }
            else
            {
                coyoteTimeCounter -= Time.deltaTime; // Cuenta regresiva
            }
            if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
                coyoteTimeCounter = 0f; // Evita que se use más de una vez
                anim.SetBool("isJumping", true); // Activa la animación de salt
            }
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            canDoubleJump = false; // Ahora sí desactivamos el doble salto solo después de usarlo
            anim.SetBool("isJumping", true); // Activa la animación de salt
        }
        // Aplicar gravedad solo si no está escalando
        if (!isClimbing)
        {
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }
        // Movemos al personaje
        charController.Move(moveDirection * Time.deltaTime);
    }
    public void Bounce(float force)
    {
        moveDirection.y = Mathf.Sqrt(force * -2f * Physics.gravity.y);
    }
    public void Respawn(Vector3 spawnPosition)
    {
        transform.position = spawnPosition;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WallLadder"))
        {
            isClimbing = true;
            moveDirection.y = 0f; // Evitar caída al entrar a la escalera
            charController.slopeLimit = 90f; // Permitir escalada libre
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WallLadder"))
        {
            isClimbing = false;
            charController.slopeLimit = 45f; // Restaurar límite de inclinación
        }
    }
}
