using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class GroundControl : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        EventManager.Trigger("Landing");
        if (other.gameObject.tag == "Escritorio")       //If the player is standing on a desk
        {
            player.transform.parent = other.transform;  //We make the player depend on the other colission's movement
        }
    }

    private void OnTriggerStay(Collider other)
    {
        EventManager.Trigger("Landing");   //We tell the Player that it's on the ground
        if (other.gameObject.tag == "Escritorio")
        {
            player.transform.parent = other.transform;  //We make the player depend on the other colission's movement
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EventManager.Trigger("Jumping");    //We tell the Player it's on the air.
        if (other.gameObject.tag == "Escritorio")       
        {
            player.transform.parent = null;//We make the player independant
        }
    }
}
