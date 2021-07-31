using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public class JumpBoost : PowerUp
{
    public override void Activate()
    {
        activated = true;
        Hide();
        EventManager.Trigger("JumpBoost", 12f);
        EventManager.Trigger("StartPowerUpTimer", originalTime, type);
        Destroy(gameObject);
    }
}
