using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{

    public override void Activate()
    {
        StartCoroutine(startCicle());
    }

    IEnumerator startCicle()
    {
        activated = true;
        Hide();
        EventManager.Trigger("SpeedBoost", 2f);
        EventManager.Trigger("StartPowerUpTimer", originalTime, type);
        yield return new WaitForSeconds(originalTime);
        activated = false;
        time = originalTime;
        EventManager.Trigger("StopPowerUpTimer");
        EventManager.Trigger("SpeedBoost", 1f);
        Destroy(gameObject);
    }


    void Update()
    {
        if (activated)
        {
            time -= Time.deltaTime;
        }
    }
}
