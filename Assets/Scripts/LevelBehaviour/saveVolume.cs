using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveVolume : MonoBehaviour
{
    public float volume;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);      //We dont destroy this object so that the sound volume is lowered in the upcoming levels.
    }

    public void setVolume(float value)
    {
        volume = value;             //Saves the volume value
    }
}
