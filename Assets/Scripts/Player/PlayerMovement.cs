﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

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
        PlayerController _controller;
        public GameObject pausePanel;
        public GameObject fpsCamera;

        private void Start()
        {
            finalSpeed = speed;
            _controller = new PlayerController(this);
        }

        private void Update()
        {
            _controller.OnUpdate();
        }

        public void move()
        {
            float horizontalMovement = Input.GetAxis(horizontalMovementAxisNamespace);      //We get the horizontal axis value
            float forwardMovement = Input.GetAxis(forwardMovementAxisNamespace);            //We get the vertical axis value

            if (horizontalMovement != 0 || forwardMovement != 0)    //if the player is moving
            {
                Vector3 totalMovement = transform.forward * forwardMovement + transform.right * horizontalMovement; //gets the correct orientation
                animator.SetFloat(runningSpeedParameterName, 0.5f); //Sets the blend tree's value
                transform.position += totalMovement * finalSpeed * Time.deltaTime; //moves the player
            }
            else animator.SetFloat(runningSpeedParameterName, 0.2f);    //Sets the blend tree's value
        }

        public void jump()
        {
            if (isGrounded)
            {
                playerBody.velocity = Vector3.zero;     //We reset the player's momentum
                playerBody.AddForce(Vector3.up * jumpForce, jumpForceMode);     //Adds a upward force which makes it jump
                SoundManager.instance.PlaySound(SoundID.JUMP);  //Plays a sound effect
            }
        }

        public void run()
        {
            finalSpeed = runningSpeed;  //Makes the moving speed faster
            animator.SetFloat(runningSpeedParameterName, 0.9f); //Sets the blend tree's value
        }

        public void walk()
        {
            finalSpeed = speed;     //Makes the speed slower
        }

        public void onGround()
        {
            isGrounded = true;             
            animator.SetBool(groundParameterName, true);    //Sets the animator parameter
        }

        public void onAir()
        {
            isGrounded = false;
            animator.SetBool(groundParameterName, false);   //Sets the animator parameter
        }
    }
}
