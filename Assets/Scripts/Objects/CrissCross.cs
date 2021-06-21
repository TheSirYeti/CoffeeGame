using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrissCross : MonoBehaviour
{
    public Vector3 barsRotationValues;
    public Vector3 floorRotationValues;

    public Transform bars;
    public Transform floor;

    private void FixedUpdate()
    {
        bars.Rotate(barsRotationValues);
        floor.Rotate(floorRotationValues);
    }
}
