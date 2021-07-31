using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP Final - Juan Pablo Rshaid
public class SpeedBoost : PowerUp
{

    public override void Activate()
    {
        activated = true;
        Hide();
        EventManager.Trigger("SpeedBoost", 2f);
        EventManager.Trigger("StartPowerUpTimer", originalTime, type);
        Destroy(gameObject);
    }
}
