using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private Transform playerTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerTransform = transform;
    }

    void Update()
    {
        // Movimiento horizontal
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // Calcular la dirección del movimiento del jugador
        Vector3 moveDirectionHor = new Vector3(hAxis, 0, vAxis);
        moveDirectionHor = moveDirectionHor.normalized * moveSpeed;

        // Movimiento vertical (salto)
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection.y = jumpSpeed;
        }

        // Aplicar la gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        // Sumar los movimientos horizontal y vertical
        moveDirection.x = moveDirectionHor.x;
        moveDirection.z = moveDirectionHor.z;

        // Mover al personaje
        controller.Move(moveDirection * Time.deltaTime);

        // Rotar al personaje hacia la dirección de movimiento
        if (moveDirectionHor.magnitude > 0.01f)
        {
            playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation,Quaternion.LookRotation(moveDirectionHor),Time.deltaTime * 10f);
        }
    }
}

