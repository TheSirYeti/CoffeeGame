using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : PowerUp
{

    public override void Activate()
    {
        StartCoroutine(startCicle());
    }

    IEnumerator startCicle()
    {
        activated = true;
        Hide();
        EventManager.Trigger("JumpBoost", 12f);
        EventManager.Trigger("StartPowerUpTimer", originalTime, type);
        yield return new WaitForSeconds(originalTime);
        activated = false;
        time = originalTime;
        EventManager.Trigger("StopPowerUpTimer");
        EventManager.Trigger("JumpBoost", 6f);
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
