using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP Final - Juan Pablo Rshaid
public class PowerUpClock : MonoBehaviour
{
    public float totalTime;
    public float time;
    public Image uiElement;

    public PowerUp.PowerType powerUp;

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
        if (powerUp == (PowerUp.PowerType)parameters[1])
        {
            time = (float)parameters[0];
            totalTime = (float)parameters[0];
            uiElement.enabled = true;
        }
    }

    public void StopCounter(object[] parameters)
    {
        uiElement.enabled = false;
        SoundManager.instance.PlaySound(SoundID.POWERUP_OVER);
        switch (powerUp)
        {
            case PowerUp.PowerType.JUMP_BOOST:
                EventManager.Trigger("JumpBoost", 6f);
                break;
            case PowerUp.PowerType.SPEED_BOOST:
                EventManager.Trigger("SpeedBoost", 1f);
                break;
            case PowerUp.PowerType.SHIELD_BOOST:
                EventManager.Trigger("DisableShield");
                break;
        }
    }

}
