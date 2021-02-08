using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class PlayerInteractive : MonoBehaviour
    {
        [SerializeField] private float rayLength = 4.3f;
        [SerializeField] private KeyCode interactiveKeyCode = KeyCode.E;
        [SerializeField] private string objectTag;
        [SerializeField] private InteractingPopUpController interactingPopUpController;
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
            {
                objectTag = hit.transform.tag;
            }
        }

        private void CheckObject()
        {

            switch (objectTag)
            {
                case "Collectable":
                    CheckCollect("Collect");
                    break;
                case "Item":
                    CheckCollect("Take Item");
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

        private void CheckCollect(string message)
        {
            interactingPopUpController.SetTextAndMessage(interactiveKeyCode.ToString(), message);
            if (Input.GetKeyDown(interactiveKeyCode))
            {
                if (hit.transform != null)
                {
                    Destroy(hit.transform.gameObject);
                    objectTag = "";
                }
            }

        }



        /* I LOVE ZOMBIE CODES <3

        private void RayDebug()
        {
            if (Physics.Raycast(ray, out hit, rayLength))
                Debug.DrawLine(ray.origin, hit.point, Color.green);
            else
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * rayLength, Color.red);
        }

        */
    }

}
