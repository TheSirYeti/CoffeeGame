using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class lossCondition : MonoBehaviour
{
    public PlayerController player;
    public timeRemaining timer;
    public WinLossManager winLossManager;

    private void Update()
    {
        if (player.transform.position.y <= -10f || timer.getTimeRemaining() == 0 || player.hp <= 0)
        {
            player.stopMovement();
            winLossManager.disableUI();
            winLossManager.lose();
        }
    }
}
