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
            c.a = 1f;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
        else
        {
            Color c = gameObject.GetComponent<Renderer>().material.color;
            c.a = 0.5f;
            gameObject.GetComponent<Renderer>().material.color = c;
        }
    }

    IEnumerator togglePlatform()
    {
        yield return new WaitForSeconds(timeToToggle);
        collider.enabled = !collider.enabled;
        StartCoroutine(togglePlatform());
    }
}
