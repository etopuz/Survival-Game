using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerScriptSystem
{
    public class FPSCameraController : MonoBehaviour
    {
        private readonly float mouseSensitivity = 100f;
        private Transform playerBody;
        private float xRotation = 0f;
        public bool isCameraFreeze = false;

        void Awake()
        {
            playerBody = GameObject.FindGameObjectWithTag("Player").transform;
            Cursor.lockState = CursorLockMode.Locked;
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            CameraRotation();
        }

        private void CameraRotation()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            if (!isCameraFreeze)
            {
                playerBody.Rotate(Vector3.up * mouseX);
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            }

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }
}
