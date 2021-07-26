﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBoost : PowerUp
{
    public override void Activate()
    {
        Hide();
        EventManager.Trigger("EnableShield");
        Debug.Log(type);
        EventManager.Trigger("StartPowerUpTimer", originalTime, type);
        Destroy(gameObject);
    }
}
