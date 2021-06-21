using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    void Start()
    {
        if (!SoundManager.instance.isMusicPlaying(MusicID.MAINSONG))
        {
            SoundManager.instance.PlayMusic(MusicID.MAINSONG);
        }
    }
}
