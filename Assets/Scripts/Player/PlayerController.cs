using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;

namespace Player.Controller
{
    public class PlayerController : PlayerBehaviour
    {
        public PlayerMovement movement;
        private string jumpButtonName = "Jump";
        private string runningButtonNamespace = "Run";
        public bool isJumping;
        private float rampRayLength = 3f;
        private void FixedUpdate()
        {
            movement.move();
            if (Input.GetButtonDown(jumpButtonName))
            {
                movement.jump();
            }

            if (Input.GetButtonDown(runningButtonNamespace))
            {
                movement.run();
            }

            if (Input.GetButtonUp(runningButtonNamespace))
            {
                movement.walk();
            }
        }


    }
}
