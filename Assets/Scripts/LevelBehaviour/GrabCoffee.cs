using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCoffee : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Terminar nivel
        }
    }
}
