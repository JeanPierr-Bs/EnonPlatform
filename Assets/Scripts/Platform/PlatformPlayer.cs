using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class PlatformPlayer : MonoBehaviour
{
    CharacterController charController;
    Vector3 groundPos;
    Vector3 lastGroundPos;
    Vector3 currentPos;
    string groundName;
    string lastGroundName;
    bool isJump;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Platform")
        {
            if (!isJump)
            {
                RaycastHit hit;
                if(Physics.SphereCast(transform.position, charController.radius, -transform.up, out hit))
                {
                    GameObject inGround = hit.collider.gameObject;//Almacena el objeto del RayCast
                    groundName = inGround.name;
                    groundPos = inGround.transform.position;//Posicion del objeto
                    if(groundPos != lastGroundPos && groundName == lastGroundName)
                    {
                        currentPos = Vector3.zero;//Resetea la posicion de player
                        currentPos += groundPos - lastGroundPos;//Calcula donde se mueve el personaje
                        charController.Move(currentPos);//Agrega movimiento 
                    }
                    lastGroundName = groundName;
                    lastGroundPos = groundPos;
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (!charController.isGrounded)//Si el player no esta en el piso
                {
                    currentPos = Vector3.zero;
                    lastGroundPos = Vector3.zero;
                    lastGroundName = null;
                    isJump = true;
                }
            }
            if (charController.isGrounded)
            {
                isJump = false;
            }
        }
    }
}
