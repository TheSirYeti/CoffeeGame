using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpClock : MonoBehaviour
{
    public float totalTime;
    public float time;
    public Image uiElement;
    public PowerUp.PowerType type;

    private void Start()
    {
        EventManager.UnSubscribe("StartPowerUpTimer", StartCounter);
        EventManager.UnSubscribe("StopPowerUpTimer", StopCounter);
        EventManager.Subscribe("StartPowerUpTimer", StartCounter);
        EventManager.Subscribe("StopPowerUpTimer", StopCounter);
    }

    private void Update()
    {
        if (uiElement.enabled)
        {
            time -= Time.deltaTime;
            uiElement.fillAmount = time / totalTime;
            if (time <= 0) StopCounter(null);
        }
    }

    public void StartCounter(object[] parameters)
    {
        if (type == (PowerUp.PowerType)parameters[1])
        {
            time = (float)parameters[0];
            totalTime = (float)parameters[0];
            uiElement.enabled = true;
        }
        else Debug.Log("Nope");
    }

    public void StopCounter(object[] parameters)
    {
        uiElement.enabled = false;
    }

}
