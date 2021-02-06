using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class PlayerAnimationController : Player
    {
        private Animator playerAnimator;

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        public void FixedUpdate()
        {
            CheckState();
        }

        public void CheckState()
        {
            switch (Player.state)
            {
                case Player.State.Idle:
                    PlayIdle();
                    break;
                case Player.State.Running:
                    PlayRunning();
                    break;
                case Player.State.Jumping:
                    PlayJumping();
                    break;
                case Player.State.Attacking:
                    PlayAttacking();
                    break;
                case Player.State.Mining:
                    PlayMining();
                    break;
                case Player.State.Dying:
                    PlayDying();
                    break;
                default:
                    break;
            }

        }

        public void PlayIdle()
        {
            playerAnimator.SetBool("isRunning", false);
            StopAll();
        }

        public void PlayRunning()
        {
            playerAnimator.SetBool("isRunning", true);
        }

        public void PlayJumping()
        {
            playerAnimator.SetTrigger("Jumping");
        }

        public void PlayAttacking()
        {
            playerAnimator.SetTrigger("Attacking");
        }

        public void PlayMining()
        {
            playerAnimator.SetTrigger("Mining");
        }

        public void PlayDying()
        {
            playerAnimator.SetTrigger("Dying");
        }

        public void StopAll()
        {
            playerAnimator.ResetTrigger("Jumping");
            playerAnimator.ResetTrigger("Attacking");
            playerAnimator.ResetTrigger("Mining");
            playerAnimator.ResetTrigger("Dying");
        }

    }

}
