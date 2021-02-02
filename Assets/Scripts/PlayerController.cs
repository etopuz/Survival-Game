using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    [Header("Control")]
    private CharacterController controller;
    private Vector3 velocity;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpHeight = 3f;

    [Header("Checking Is Grounded")]
    private Transform groundCheck;
    private LayerMask groundMask;
    [SerializeField]
    private float groundDistance = 0.42f;
    [SerializeField]
    bool isGrounded;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        groundMask = LayerMask.GetMask("Ground");
        groundCheck = transform.Find("GroundCheck");
    }

    void Update()
    {
        CheckIsGrounded();
        Move();
        Jump();
        Gravity();
    }


    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
            Player.state = Player.State.Jumping;
        }
            
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;
    }

    private void Gravity()
    {
        velocity.y += gravity * Time.deltaTime * 2;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        if (vertical != 0)
            Player.state = Player.State.Running;
        else
            Player.state = Player.State.Idle;
    }


}
