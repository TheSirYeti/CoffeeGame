using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;

namespace Player.Controller
{
    public class PlayerController : PlayerBehaviour
    {
        public      PlayerMovement      movement;
        private     string              jumpButtonName              = "Jump";
        private     string              runningButtonNamespace      = "Run";
        public      bool                isJumping;
        private     float               rampRayLength               = 3f;
        private void FixedUpdate()
        {
            checkMove();
            checkJump();
            checkRunning();
        }

        public void stopMovement()
        {
            movement.stopMoving = true;
        }

        void checkMove()
        {
            if (!movement.stopMoving)
                movement.move();
        }

        void checkJump()
        {
            if (Input.GetButtonDown(jumpButtonName))
                movement.jump();
        }

        void checkRunning()
        {
            if (Input.GetButtonDown(runningButtonNamespace))
                movement.run();

            if (Input.GetButtonUp(runningButtonNamespace))
                movement.walk();
        }
    }
}
