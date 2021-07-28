using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCrane : MonoBehaviour
{
    public Vector3 craneMinRotationValues;
    public Vector3 craneMaxRotationValues;

    Vector3 craneRotation;

    public Transform crane;
    public GameObject light;

    private void Start()
    {
        StartCoroutine(SpinCycle());
        craneRotation = craneMinRotationValues;
    }

    void FixedUpdate()
    {
        crane.Rotate(craneRotation);
    }

    IEnumerator SpinCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f);
            craneRotation = craneRotation * -1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            light.SetActive(true);
            craneRotation = craneMaxRotationValues * Mathf.Sign(craneRotation.y);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            light.SetActive(false);
            craneRotation = craneMinRotationValues * Mathf.Sign(craneRotation.y);
        }
    }
}
