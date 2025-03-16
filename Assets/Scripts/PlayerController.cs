using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight = 2f;
    private bool canDoubleJump;
    private Vector3 velocity;
    private Vector3 moveDirection;

    public CharacterController charController;
    private Camera playerCamera;
    private void Start()
    {
        playerCamera = Camera.main;
    }

    void Update()
    {
        HandleMove();
        HandleJump();
    }
    private void HandleMove()
    {
        Vector3 moveDir = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection.x = moveDir.x * moveSpeed;
        moveDirection.z = moveDir.z * moveSpeed;
        Cursor.lockState = CursorLockMode.Locked;//Bloquea el mouse
        Cursor.visible = false;

        charController.Move(moveDirection * Time.deltaTime * moveSpeed);

        transform.rotation = Quaternion.Euler(0f, playerCamera.transform.rotation.eulerAngles.y, 0f);
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
    }

    private void HandleJump()
    {
        if (charController.isGrounded)
        {
            moveDirection.y = 0f;
            canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
                moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump)
        {
            moveDirection.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
            canDoubleJump = false;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        charController.Move(velocity * Time.deltaTime);
    }
}
