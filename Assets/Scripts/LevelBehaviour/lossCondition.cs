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
        if (player.transform.position.y <= -10f || timer.getTimeRemaining() == 0 || player.hp <= 0) //If the player falls off the level,
                                                                                                    //runs out of time,
                                                                                                    //or runs out of lives, they lose.
        {
            player.stopMovement();              //The player stops recieving 
            winLossManager.disableUI();         //Hides the UI
            winLossManager.lose();              //Shows the Lose Panel
        }
    }
}
