using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class lossCondition : MonoBehaviour
{
    public PlayerController player;
    public WinLossManager winLossManager;

    private void Update()
    {
        if (player.transform.position.y <= -10f)
        {
            winLossManager.lose();
        }
    }
}
