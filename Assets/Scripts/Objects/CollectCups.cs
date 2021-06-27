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
            EventManager.Trigger("AddScore", cup.scoreValue);
            EventManager.Trigger("AddCup");
            Destroy(gameObject);
        }
    }
}
