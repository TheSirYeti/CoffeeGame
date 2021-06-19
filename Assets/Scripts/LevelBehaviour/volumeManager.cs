using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeManager : MonoBehaviour
{
    AudioSource[] sources;
    float volume;

    void Start()
    {
        sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];       //We get all the current sounds in the scene
        GameObject g = GameObject.FindWithTag("volume");                                    //We get the volume configuration
        if (g == null)                                      //If there's no volume configuration, we delete the object
            Destroy(gameObject);
    }

    private void Update()
    {
        GameObject g = GameObject.FindWithTag("volume");
        volume = g.GetComponent<saveVolume>().volume;   //Sets the value 
        foreach (AudioSource a in sources)
        {
            if(a.gameObject.tag != "Music")
            {
                a.volume = volume; //We lower the volume of all the clips.
            }
            
        }
    }
}
