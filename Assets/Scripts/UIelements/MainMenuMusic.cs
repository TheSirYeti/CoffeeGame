using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid

public class MainMenuMusic : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.StopAllMusic();
        SoundManager.instance.StopAllSounds();
        SoundManager.instance.PlayMusic(MusicID.ELEVATOR);
    }
}
