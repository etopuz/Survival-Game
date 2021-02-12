using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class PlayerController : MonoBehaviour
    {

        [Header("Control")]
        [SerializeField]    private float speed;
        [SerializeField]    private float sprintRatio;
        [SerializeField]    private float slowRatio;
        [SerializeField]    private float gravity;
        [SerializeField]    private float jumpHeight;
        [SerializeField]    private float originalSpeedValue;


        [Header("Checking Is Grounded")]
        [SerializeField]    private float groundDistance;
        [SerializeField]    bool isGrounded;


        private CharacterController controller;
        private Vector3 velocity;
        private Transform groundCheck;
        private LayerMask groundMask;
        private PlayerStatsController playerStatsController;

        private void Awake()
        {
            originalSpeedValue = speed;
            controller = GetComponent<CharacterController>();
            groundMask = LayerMask.GetMask("Ground");
            groundCheck = transform.Find("GroundCheck");
            playerStatsController = GetComponent<PlayerStatsController>();
        }

        void Update()
        {
            CheckIsGrounded();
            CheckIsMoving();
            CheckIsJumping();
            CheckIsTired();
            CheckSprint();
            CalculateGravity();
        }

        private void CheckIsTired()
        {
            if (playerStatsController.isTired)
                speed *= slowRatio;
            else
                speed = originalSpeedValue;
        }

        private void CheckSprint()
        {
            bool isSprinting = Player.state == Player.State.Sprinting;
            if (Input.GetKey(KeyCode.LeftShift) && !isSprinting)
                speed *= sprintRatio;
            else
                speed = originalSpeedValue;
        }

        private void CheckIsJumping()
        {
            // player can only jump when have enough stamina and should be grounded, of course player needs to press spacebar :)
            bool canJump = isGrounded && playerStatsController.isStaminaEnoughForJump;
            if (Input.GetButtonDown("Jump") && canJump)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
                Player.state = Player.State.Jumping;
                playerStatsController.DropStaminaWhenJumping();
            }

        }

        private void CheckIsGrounded()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
                velocity.y = -2f;
        }


        private void CalculateGravity()
        {
            velocity.y += gravity * Time.deltaTime * 2;
            controller.Move(velocity * Time.deltaTime);
        }


        private void CheckIsMoving()
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            controller.Move(move * speed * Time.deltaTime);

            if (vertical != 0)
            {
                if (speed == originalSpeedValue)
                    Player.state = Player.State.Running;
                else
                    Player.state = Player.State.Sprinting;
            }
                
            else
                Player.state = Player.State.Idle;
        }

        // updates speed and original speed when got powerup
        public void ChangeSpeed(float multiplier)
        {
            speed *= multiplier;
            originalSpeedValue = speed;
        }

        // updates jumpHeight when got powerup
        public void ChangeJumpHeight(float multiplier)
        {
            jumpHeight *= multiplier;
        }
    }

}
