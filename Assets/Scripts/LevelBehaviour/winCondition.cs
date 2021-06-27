using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;
using Player.Movement;

public class winCondition : MonoBehaviour
{
    public WinLossManager winLossManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")               //If we collide with the coffee machine, we win the level
        {
            EventManager.Trigger("Win");
        }
    }
}
