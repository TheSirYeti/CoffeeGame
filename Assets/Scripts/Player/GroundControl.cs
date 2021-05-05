using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class GroundControl : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        player.isJumping = false;
    }

    private void OnTriggerExit(Collider other)
    {
        player.isJumping = true;
    }
}
