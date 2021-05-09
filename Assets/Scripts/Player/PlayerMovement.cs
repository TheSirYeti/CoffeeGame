using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private     string      horizontalMovementAxisNamespace     = "Horizontal";
        private     string      forwardMovementAxisNamespace        = "Vertical";

        public      Animator    animator;
        private     string      runningSpeedParamenterName          = "runningSpeed";
        private     string      jumpTriggerParamenterName           = "jump";
        private     string      groundParamenterName                = "isGrounded";
        public      float       speed;
        public      float       runningSpeed;
        public      Rigidbody   playerBody;
        public      float       jumpForce;
        private     ForceMode   jumpForceMode                       = ForceMode.Impulse;
        private     float       finalSpeed;
        private     bool        isGrounded;
        public      bool        stopMoving                          = false;
        private     Transform   target = null;

        public      AudioSource mAudioSrc;

        private void Start()
        {
            finalSpeed = speed;
        }

        public void move()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace);
            float forwardMovement = Input.GetAxis(forwardMovementAxisNamespace);

            if (horizontalMovement != 0 || forwardMovement != 0)
            {
                Vector3 totalMovement = transform.forward * forwardMovement + transform.right * horizontalMovement;
                animator.SetFloat(runningSpeedParamenterName, 0.5f);
                transform.position += totalMovement * finalSpeed * Time.deltaTime;

            }
            else animator.SetFloat(runningSpeedParamenterName, 0.2f);
        }

        public void jump()
        {
            if (isGrounded)
            {
                playerBody.velocity = Vector3.zero;
                playerBody.AddForce(Vector3.up * jumpForce, jumpForceMode);
                mAudioSrc.Play();
            }
        }

        public void run()
        {
            finalSpeed = runningSpeed;
            animator.SetFloat(runningSpeedParamenterName, 0.9f);
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
            animator.SetBool(groundParamenterName, true);

            if (other.gameObject.tag == "Escritorio")
            {
                transform.parent = other.transform;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            isGrounded = false;
            animator.SetBool(groundParamenterName, false);

            if (other.gameObject.tag == "Escritorio")
            {
                transform.parent = null;
            }
        }
    }
}
