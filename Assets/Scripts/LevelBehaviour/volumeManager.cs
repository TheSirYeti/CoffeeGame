using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeManager : MonoBehaviour
{
    AudioSource[] sources;
    float volume;

    void Start()
    {
        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        GameObject g = GameObject.FindWithTag("volume");
        volume = g.GetComponent<saveVolume>().volume;
    }

    private void Update()
    {
        GameObject g = GameObject.FindWithTag("volume");
        volume = g.GetComponent<saveVolume>().volume;
        foreach (AudioSource a in sources)
        {
            a.volume = volume;
        }
    }
}
