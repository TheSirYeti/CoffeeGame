using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid

public class colliderTarget : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;        //This makes the player move with the platform and be able to
                                                        //move on its own
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;             //We make it independant again
    }
}
