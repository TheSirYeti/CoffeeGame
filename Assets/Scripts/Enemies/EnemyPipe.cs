﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPipe : MonoBehaviour
{
    public GameObject Fire;
    public bool isActive;


     

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            Fire.SetActive(true);
            Invoke("SetFalse", 3);
            
        }
        else
        {
            Fire.SetActive(false);
            SoundManager.instance.PlaySound(SoundID.FLAME);
            Invoke("SetTrue", 4);
        }
    }

    public void SetTrue()
    {
        isActive = true;
    }

    public void SetFalse()
    {
        isActive = false;
    }
}
