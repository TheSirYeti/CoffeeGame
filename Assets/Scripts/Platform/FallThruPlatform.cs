using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThruPlatform : MonoBehaviour
{
    [SerializeField] Collider collider;
    public Material originalMat;
    public Material emissiveMat;

    public float timeToToggle;

    private void Start()
    {
        StartCoroutine(togglePlatform());
    }

    private void Update()
    {
        changeVisibility();
    }

    public void changeVisibility()
    {
        if (collider.enabled)
        {
            gameObject.GetComponent<Renderer>().material = emissiveMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = originalMat;
        }
    }

    IEnumerator togglePlatform()
    {
        yield return new WaitForSeconds(timeToToggle);
        collider.enabled = !collider.enabled;   //Every X amount of seconds, we turn on/off the platform's collisions
        StartCoroutine(togglePlatform());
    }
}
