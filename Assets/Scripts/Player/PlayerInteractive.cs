using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class PlayerInteractive : MonoBehaviour
    {
        [SerializeField] private float rayLength = 4.3f;
        [SerializeField] private string objectTag;
        [SerializeField] private InteractingPopUpController interactingPopUpController;
        [SerializeField] private KeyCode keyCode = KeyCode.E;
        private Ray ray;
        private RaycastHit hit;

        public void Awake()
        {
            GameObject interactingPopUp = GameObject.Find("/InGameUI/InteractingPopUP");
            interactingPopUpController = interactingPopUp.GetComponent<InteractingPopUpController>();
        }

        private void FixedUpdate()
        {
            SetRayAndTag();
            CheckObject();
        }

        private void SetRayAndTag()
        {
            ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out hit, rayLength))
                objectTag = hit.transform.tag;
            else
                objectTag = "";
        }

        private void CheckObject()
        {

            switch (objectTag)
            {
                case "Collectable":
                    Collectable collectable = hit.transform.GetComponent<Collectable>();
                    interactingPopUpController.SetTextAndMessage(keyCode.ToString(), "Collect");
                    collectable.CheckCollect(hit, keyCode);
                    break;
                case "ItemStock":
                    break;
                case "Door":
                    break;
                default:
                    interactingPopUpController.ClosePopUp();
                    break;
            }
        }





    }

}
