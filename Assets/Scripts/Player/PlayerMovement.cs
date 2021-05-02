﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private string horizontalMovementAxisNamespace = "Horizontal";
        private string forwardMovementAxisNamespace = "Vertical";

        public float speed;
        public Rigidbody playerBody;
        public float jumpForce;
        private ForceMode jumpForceMode = ForceMode.Impulse;
        
        public void move()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace);
            float forwardMovement = Input.GetAxis(forwardMovementAxisNamespace);

            Vector3 totalMovement = transform.forward * forwardMovement + transform.right * horizontalMovement;

            playerBody.MovePosition(transform.position + totalMovement * (speed * Time.deltaTime));
        }

        public void jump()
        {
            playerBody.AddForce(Vector3.up * jumpForce, jumpForceMode);
        }
    }
}
