using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallThruPlatform : MonoBehaviour
{
    [SerializeField] Collider collider;

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
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.a = 1f;   //If we can jump on the platform, the object isn't transparent
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        else
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.a = 0.15f;    //If we cant jump on the platform, we make the object hard to see
            gameObject.GetComponent<Renderer>().material.color = c;
        }
    }

    IEnumerator togglePlatform()
    {
        yield return new WaitForSeconds(timeToToggle);
        collider.enabled = !collider.enabled;   //Every X amount of seconds, we turn on/off the platform's collisions
        StartCoroutine(togglePlatform());
    }
}
