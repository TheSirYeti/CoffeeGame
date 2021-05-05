using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private string horizontalMovementAxisNamespace = "Horizontal";
        private string forwardMovementAxisNamespace = "Vertical";

        public float speed;
        public float runningSpeed;
        public Rigidbody playerBody;
        public float jumpForce;
        private ForceMode jumpForceMode = ForceMode.Impulse;
        private float finalSpeed;
        private bool isGrounded;

        private void Start()
        {
            finalSpeed = speed;
        }

        public void move()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace);
            float forwardMovement = Input.GetAxis(forwardMovementAxisNamespace);

            Vector3 totalMovement = transform.forward * forwardMovement + transform.right * horizontalMovement;

            playerBody.MovePosition(transform.position + totalMovement * (finalSpeed * Time.deltaTime));
        }

        public void jump()
        {
            if (isGrounded)
            {
                playerBody.velocity = Vector3.zero;
                playerBody.AddForce(Vector3.up * jumpForce, jumpForceMode);
            }
        }

        public void run()
        {
            finalSpeed = runningSpeed;
        }

        public void walk()
        {
            finalSpeed = speed;
        }

        public void moveDown()
        {
            playerBody.MovePosition(Vector3.down * transform.position.y * 100f * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            isGrounded = true;
        }

        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
        }
    }
}
