using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Movement;

namespace Player.Controller
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement movement;
        private string jumpButtonName = "Jump";

        private void FixedUpdate()
        {
            movement.move();
            if (Input.GetButtonDown(jumpButtonName))
            {
                movement.jump();
            }
        }
    }
}
