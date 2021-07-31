using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid | Juan Cruz Cristófalo
public class PlayMusic : MonoBehaviour
{
    void Start()
    {
        if (!SoundManager.instance.isMusicPlaying(MusicID.MAINSONG))
        {
            SoundManager.instance.StopAllMusic();
            SoundManager.instance.PlayMusic(MusicID.MAINSONG, true);
        }
    }
}
