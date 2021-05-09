using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCups : MonoBehaviour
{
    public CoffeeCup cup;
    public score score;

    private void Update()
    {
        transform.Rotate(0f, 0f, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            score.setScore(cup.totalScore());
            Destroy(gameObject);
        }
    }
}
