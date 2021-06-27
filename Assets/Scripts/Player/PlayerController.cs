﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Player.Movement;
using Camera.Behaviour;

namespace Player.Controller
{
    public class PlayerController : PlayerBehaviour
    {
        public      PlayerMovement      movement;
        private     string              jumpButtonName              = "Jump";
        private     string              runningButtonNamespace      = "Run";
        public      bool                isJumping;
        public      Animator            animator;
        public      Action              artificialUpdate;

        public PlayerController(PlayerMovement playerMovement)
        {
            movement = playerMovement;
            artificialUpdate = CheckInputs;
        }
        
        public void OnUpdate()
        {
            artificialUpdate();
        }

        public void StopMovement()
        {
            movement.stopMoving = true;     //Tells the body to stop moving
        }

        void CheckInputs()
        {
            if (!movement.stopMoving)   //If it isn't told to stop, keeps on moving
                movement.move();

            if (Input.GetButtonDown(jumpButtonName))        //If the player hits the jump button, it jumps
                movement.jump();

            if (Input.GetButtonDown(runningButtonNamespace))    // If the player hits the run button, it runs
                movement.run();

            if (Input.GetButtonUp(runningButtonNamespace))  // If the player lets go of the run button, it stops running
                movement.walk();

            if (Input.GetKeyDown(KeyCode.Escape))
            {

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SoundManager.instance.PauseAllMusic();
                SoundManager.instance.PauseAllSounds();
                SoundManager.instance.PlayMusic(MusicID.ELEVATOR, true);
                movement.pausePanel.SetActive(true);
                movement.fpsCamera.GetComponent<CameraLook>().enabled = false;
                artificialUpdate = PausedMenu;
                Time.timeScale = 0f;
            }
        }

        void PausedMenu()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SoundManager.instance.ResumeAllMusic();
                SoundManager.instance.ResumeAllSounds();
                SoundManager.instance.StopMusic(MusicID.ELEVATOR);
                movement.pausePanel.SetActive(false);
                movement.fpsCamera.GetComponent<CameraLook>().enabled = true;
                artificialUpdate = CheckInputs;
                Time.timeScale = 1f;
            }
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
