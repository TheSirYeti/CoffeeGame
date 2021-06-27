using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class GroundControl : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        player.movement.OnGround();
        if (other.gameObject.tag == "Escritorio")       //If the player is standing on a desk
        {
            player.transform.parent = other.transform;  //We make the player depend on the other colission's movement
        }
    }

    private void OnTriggerStay(Collider other)
    {
        player.movement.OnGround();    //We tell the Player that it's on the ground
        if (other.gameObject.tag == "Escritorio")
        {
            player.transform.parent = other.transform;  //We make the player depend on the other colission's movement
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.movement.OnAir();    //We tell the Player it's on the air.
        if (other.gameObject.tag == "Escritorio")       
        {
            player.transform.parent = null;//We make the player independant
        }
    }
}
