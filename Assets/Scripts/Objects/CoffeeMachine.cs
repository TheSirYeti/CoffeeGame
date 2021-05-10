using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 2f);       //Rotates the object on its own axis.
    }
}
