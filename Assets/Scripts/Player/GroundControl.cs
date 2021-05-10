using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class GroundControl : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        player.movement.onGround();
        if (other.gameObject.tag == "Escritorio")
        {
            player.transform.parent = other.transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        player.movement.onGround();
        if (other.gameObject.tag == "Escritorio")
        {
            player.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.movement.onAir();
        if (other.gameObject.tag == "Escritorio")
        {
            player.transform.parent = null;
        }
    }
}
