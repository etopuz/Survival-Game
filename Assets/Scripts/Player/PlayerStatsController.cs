using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SurvivalUISystem;
using System;

namespace PlayerScriptSystem
{
    // This class control and checks health, hunger, stamina and updates UI with using UIHandler class.

    public class PlayerStatsController : MonoBehaviour
    {
        private const float LIMIT  = 0f;

        [Header("Health Stats")]
        public bool isDead = false;
        [SerializeField]    private float playerHealth;
        [SerializeField]    private float maxHealth;

        [Header("Stamina Stats")]
        public bool isStaminaEnoughForJump = true;
        public bool isTired = false;
        [SerializeField]    private float playerStamina;
        [SerializeField]    private float maxStamina;
        [SerializeField]    private float staminaDrain;
        [SerializeField]    private float staminaRegen;
        [SerializeField]    private float jumpCost;


        [Header("Hunger Stats")]
        [SerializeField]    private float playerHunger;
        [SerializeField]    private float maxHunger;
        [SerializeField]    private float hungerDrain;

        [Header("Damages")]
        [SerializeField]    private float hungerDamageRate;

        [Header("References")]
        [SerializeField]    private SurvivalUIHandler survivalUIHandler;



        private void Awake()
        {
            playerHealth = maxHealth;
            playerStamina = maxStamina;
            playerHunger = maxHunger;
            survivalUIHandler = GameObject.Find("/InGameUI").GetComponent<SurvivalUIHandler>();
        }

        private void Update()
        {
            isStaminaEnoughForJump = jumpCost <= playerStamina;
            isTired = playerStamina <= LIMIT+2f;
            ControlHunger();
            UpdateSurvivalUI();
            ControlHealth();
            ControlStamina();
        }



        private void ControlHunger()
        {
            if (playerHunger <= maxHunger)
            {
                playerHunger -= hungerDrain * Time.deltaTime;
                
                if (playerHunger <= LIMIT)
                {
                    playerHunger = LIMIT;
                    TakeDamage(hungerDamageRate * Time.deltaTime);
                }
            }
            else // if hunger is overloading, for instance eating something when hunger is full
            {
                playerHunger = maxHunger;
            }
        }


        // Adds stamina if player in idle state, if sprinting drains stamina
        private void ControlStamina()
        {
            if (playerStamina >= maxStamina)
                playerStamina = maxStamina;

            else if (isTired && Player.state != Player.State.Idle)
                playerStamina = LIMIT;

            switch (Player.state)
            {
                case Player.State.Sprinting:
                    playerStamina -= staminaDrain * Time.deltaTime;
                    break;
                case Player.State.Idle:
                    playerStamina += staminaRegen * Time.deltaTime;
                    break;
            }
        }

        private void ControlHealth()
        {
            if (playerHealth <= LIMIT && isDead == false)
            {
                isDead = true;
                playerHealth = LIMIT;
                Player.state = Player.State.Dying;
            }

            // if health is overloading, for instance using bandage when player health is max
            else if (playerHealth > maxHealth)
                playerHealth = maxHealth;
        }

        // This method updates UI in every frame
        private void UpdateSurvivalUI()
        {
            survivalUIHandler.ChangeHealthImage(playerHealth / maxHealth);
            survivalUIHandler.ChangeHungerImage(playerHunger / maxHunger);
            survivalUIHandler.ChangeStaminaImage(playerStamina / maxStamina);
        }

        // Take instant damage method
        public void TakeDamage(float damageAmount)
        {
            playerHealth -= damageAmount;
        }

        public void DropStaminaWhenJumping()
        {
            playerStamina -= jumpCost;
        }




    }

}
