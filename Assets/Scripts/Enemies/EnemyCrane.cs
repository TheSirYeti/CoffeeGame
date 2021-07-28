using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrane : MonoBehaviour
{
    public Vector3 craneRotationValues;

    public Transform crane;

    // Update is called once per frame
    void FixedUpdate()
    {
        crane.Rotate(craneRotationValues);
    }
}
