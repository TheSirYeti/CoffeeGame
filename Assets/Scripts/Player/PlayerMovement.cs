using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

//TP2 - Rshaid, Juan Pablo

namespace Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private     string      horizontalMovementAxisNamespace     = "Horizontal";
        private     string      forwardMovementAxisNamespace        = "Vertical";

        public      Animator    animator;
        private     string      runningSpeedParameterName          = "runningSpeed";
        private     string      groundParameterName                = "isGrounded";
        public      float       speed;
        public      float       runningSpeed;
        public      Rigidbody   playerBody;
        public      float       jumpForce;
        private     ForceMode   jumpForceMode                       = ForceMode.Impulse;
        private     float       finalSpeed;
        private     bool        isGrounded;
        public      bool        stopMoving                          = false;
        float speedMultiplier = 1;
        public float yDeathHeight;
        PlayerController _controller;
        public GameObject pausePanel;
        public GameObject fpsCamera;
        public GameObject fpsCamera2;

        private void Start()
        {
            finalSpeed = speed;
            _controller = new PlayerController(this);
            EventManager.Subscribe("Jumping", OnAir);
            EventManager.Subscribe("Landing", OnGround);
            EventManager.Subscribe("JumpBoost", JumpBoost);
            EventManager.Subscribe("SpeedBoost", SpeedBoost);
        }

        private void Update()
        {
            _controller.OnUpdate();

            if (transform.position.y <= yDeathHeight)
                EventManager.Trigger("Lose");
        }

        public void Move()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace);      //We get the horizontal axis value
            float forwardMovement = Input.GetAxis(forwardMovementAxisNamespace);            //We get the vertical axis value

            if (horizontalMovement != 0 || forwardMovement != 0)    //if the player is moving
            {
                Vector3 totalMovement = transform.forward * forwardMovement + transform.right * horizontalMovement; //gets the correct orientation
                animator.SetFloat(runningSpeedParameterName, 0.5f); //Sets the blend tree's value
                playerBody.MovePosition(transform.position + totalMovement * finalSpeed * Time.deltaTime * speedMultiplier);
                //transform.position += totalMovement * finalSpeed * Time.deltaTime; //moves the player
            }
            else animator.SetFloat(runningSpeedParameterName, 0.2f);    //Sets the blend tree's value
        }

        public void Jump()
        {
            if (isGrounded)
            {
                playerBody.velocity = Vector3.zero;     //We reset the player's momentum
                playerBody.AddForce(Vector3.up * jumpForce, jumpForceMode);     //Adds a upward force which makes it jump
                SoundManager.instance.PlaySound(SoundID.JUMP);  //Plays a sound effect
            }
        }

        public void Run()
        {
            finalSpeed = runningSpeed;  //Makes the moving speed faster
            animator.SetFloat(runningSpeedParameterName, 0.9f); //Sets the blend tree's value
        }

        public void Walk()
        {
            finalSpeed = speed;     //Makes the speed slower
        }

        public void OnGround(object[] parameters)
        {
            isGrounded = true;             
            animator.SetBool(groundParameterName, true);    //Sets the animator parameter
        }

        public void OnAir(object[] parameters)
        {
            isGrounded = false;
            animator.SetBool(groundParameterName, false);   //Sets the animator parameter
        }

        public void JumpBoost(object[] parameters)
        {
            jumpForce = (float)parameters[0];
        }

        public void SpeedBoost(object[] parameters)
        {
            speedMultiplier = (float)parameters[0];
        }
    }
}
