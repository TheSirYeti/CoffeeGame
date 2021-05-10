using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class saveVolume : MonoBehaviour
{
    public float volume;
    public Slider slider;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        volume = slider.value;
    }
}
