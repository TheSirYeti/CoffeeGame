using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTarget : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.transform.parent = null;
    }
}
