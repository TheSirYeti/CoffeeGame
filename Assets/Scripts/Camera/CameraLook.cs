using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera.Behaviour
{
    public class CameraLook : MonoBehaviour
    {
        public float mouseSensitivity = 500f;
        private string horizontalMovementAxisNamespace = "Mouse X";
        private string verticalMovementAxisNamespace = "Mouse Y";
        private float totalRotation = 0f;        //We use this as the parameter we send to the Player's Transform component

        public Transform playerBody;
        
        void FixedUpdate()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace) * mouseSensitivity * Time.deltaTime;      //We get the mouse horizontal input
            float verticalMovement = Input.GetAxis(verticalMovementAxisNamespace) * mouseSensitivity * Time.deltaTime;          //We get the mouse vertical input

            totalRotation -= verticalMovement; //We use this parameter to determine the Y movement in the camera
            totalRotation = Mathf.Clamp(totalRotation, -90f, 90f); //With this the user cannot rotate beyond the body's head or toes

            transform.localRotation = Quaternion.Euler(totalRotation, 0f, 0f); //We rotate the camera's Y value
            playerBody.Rotate(Vector3.up * horizontalMovement); //We make the BODY rotate on X, not the camera
        }
    }
}