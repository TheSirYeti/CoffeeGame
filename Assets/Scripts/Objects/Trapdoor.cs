using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Rshaid, Juan Pablo 
public class Trapdoor : MonoBehaviour
{
    public float originalRotation;
    public float activeRotation;

    public Transform door;

    private void OnTriggerEnter(Collider other)
    {
        door.rotation = Quaternion.Euler(0, 0, activeRotation);
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Exit());
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(2);
        door.rotation = Quaternion.Euler(0, 0, originalRotation);
    }
}
