using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public class FallThruPlatform : MonoBehaviour
{
    [SerializeField] Collider collider;
    public Material originalMat;
    public Material emissiveMat;

    public float timeActive;
    public float timeOff;

    private void Start()
    {
        StartCoroutine(togglePlatform());
    }

    IEnumerator togglePlatform()
    {
        while (true)
        {
            collider.enabled = true;                                        //Every X amount of seconds, we turn on/off the platform's collisions
            gameObject.GetComponent<Renderer>().material = emissiveMat;
            yield return new WaitForSeconds(timeActive);
            collider.enabled = false;
            gameObject.GetComponent<Renderer>().material = originalMat;
            yield return new WaitForSeconds(timeOff);
        }
    }
}
