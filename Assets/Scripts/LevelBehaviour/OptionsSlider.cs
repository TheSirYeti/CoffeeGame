using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSlider : MonoBehaviour
{
    public Slider slider;
    public saveVolume volume;

    private void Update()
    {
        volume.volume = slider.value;       //Sets the value of the volume.
    }

}
