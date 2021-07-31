using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid

public class Shuriken : MonoBehaviour
{
    Vector3 original;
    private void Awake()
    {
        original = transform.forward;
    }
    private void FixedUpdate()
    {
        transform.position += original / 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
