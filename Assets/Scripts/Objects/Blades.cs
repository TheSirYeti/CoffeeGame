using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Rshaid, Juan Pablo
public class Blades : MonoBehaviour
{
    public Vector3 rotationValues;
    void FixedUpdate()
    {
        transform.Rotate(rotationValues);
    }
}
