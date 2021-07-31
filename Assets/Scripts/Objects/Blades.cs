using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public class Blades : MonoBehaviour
{
    public Vector3 rotationValues;
    void FixedUpdate()
    {
        transform.Rotate(rotationValues);
    }
}
