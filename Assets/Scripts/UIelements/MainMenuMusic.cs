using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Rshaid, Juan Pablo

public class MainMenuMusic : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.StopAllMusic();
        SoundManager.instance.StopAllSounds();
        SoundManager.instance.PlayMusic(MusicID.ELEVATOR);
    }
}
