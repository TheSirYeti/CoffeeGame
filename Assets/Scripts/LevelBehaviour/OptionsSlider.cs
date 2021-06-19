using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSlider : MonoBehaviour
{
    public Slider sfxSlider;
    public Slider musicSlider;

    private void Start()
    {
        sfxSlider.value = SoundManager.instance.volumeSFX;
        musicSlider.value = SoundManager.instance.volumeMusic;
    }

    public void SetVolumeSFX()
    {
        SoundManager.instance.ChangeVolumeSound(sfxSlider.value);
    }

    public void SetVolumeMusic()
    {
        SoundManager.instance.ChangeVolumeMusic(musicSlider.value);
    }
}
