using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class PlayerMotor : MonoBehaviour
{
    private CharacterController charController;
    private Vector3 playerVelocity;
    private float speed = 5f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1.2f;

    
    void Start()
    {
        charController = GetComponent <CharacterController>();
    }

    
    void Update()
    {
        isGrounded = charController.isGrounded;   
    }

    //Treba da dobija inputs iz InputMenager.cs i da ih dodeljuje CharacterController-u
    public void ProcessMove(Vector3 input) {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        charController.Move(speed * Time.deltaTime * transform.TransformDirection(moveDirection));
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -2f; ;
        }
        charController.Move(playerVelocity * Time.deltaTime);
        //Debug.Log(playerVelocity.y);
    }

    public void Jump() {
        if (isGrounded) {
            playerVelocity.y = MathF.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
