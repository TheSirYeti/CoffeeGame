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
        public      Animator            animator;
        private void Update()
        {
            checkMove();
            checkJump();
            checkRunning();
        }

        public void stopMovement()
        {
            movement.stopMoving = true;     //Tells the body to stop moving
        }

        void checkMove()
        {
            if (!movement.stopMoving)   //If it isn't told to stop, keeps on moving
                movement.move();
        }

        void checkJump()
        {
            if (Input.GetButtonDown(jumpButtonName))        //If the player hits the jump button, it jumps
                movement.jump();
        }

        void checkRunning()
        {
            if (Input.GetButtonDown(runningButtonNamespace))    // If the player hits the run button, it runs
                movement.run();

            if (Input.GetButtonUp(runningButtonNamespace))  // If the player lets go of the run button, it stops running
                movement.walk();
        }

        public void ThumbsUP()
        {
            animator.SetTrigger("ThumbsUp");
        }

        public void playSFX()
        {
            SoundManager.instance.PlaySound(SoundID.NICE);
        }
    }
}
