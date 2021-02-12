using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayerScriptSystem;

namespace SurvivalUISystem
{
    public class SurvivalUIHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image healthImage;
        [SerializeField] private Image staminaImage;
        [SerializeField] private Image hungerImage;

        private void Awake()
        {
            healthImage = transform.Find("SurvivalUI/HealthUI_Green").GetComponent<Image>();
            staminaImage = transform.Find("SurvivalUI/StaminaUI").GetComponent<Image>();
            hungerImage = transform.Find("SurvivalUI/HungerUI").GetComponent<Image>();

        }

        public void ChangeHealthImage(float healthOccupancy)
        {
            healthImage.fillAmount = healthOccupancy;
            healthImage.enabled = true;
        }

        public void ChangeStaminaImage(float staminaOccupancy)
        {
            staminaImage.fillAmount = staminaOccupancy;
            staminaImage.enabled = true;
        }

        public void ChangeHungerImage(float hungerOccupancy)
        {
            hungerImage.fillAmount = hungerOccupancy;
            hungerImage.enabled = true;
        }

    }
}

