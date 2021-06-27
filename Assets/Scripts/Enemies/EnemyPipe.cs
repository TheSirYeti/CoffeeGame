using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Juan Cruz Cristófalo
public class EnemyPipe : MonoBehaviour
{
    public GameObject Fire;
    public bool isActive;
    public float activeTime = 3;
    public float inactiveTime = 4;

    private void Start()
    {
        Invoke("SetTrue", inactiveTime);
    } 

    public void SetTrue()
    {
        Fire.SetActive(true);
        SoundManager.instance.PlaySound(SoundID.FLAME);
        Invoke("SetFalse", activeTime);
    }

    public void SetFalse()
    {
        Fire.SetActive(false);
        Invoke("SetTrue", inactiveTime);
    }
}
