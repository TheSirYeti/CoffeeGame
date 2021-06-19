using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Controller;

public class CollectCups : MonoBehaviour
{
    public CoffeeCup cup;
    public score score;
    public PlayerController player;

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.ThumbsUP();        //If the player collides with the cup, the animation plays
            SoundManager.instance.PlaySound(SoundID.NICE);
            score.setScore(cup.totalScore());       //Adds the score to the UI
            Destroy(gameObject);
        }
    }
}
