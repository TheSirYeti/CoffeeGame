using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP2 - Rshaid, Juan Pablo
public class score : MonoBehaviour
{
    float totalTally;
    public Text scoreText;

    private void Start()
    {
        EventManager.Subscribe("AddCup", UpdateText);
        EventManager.Subscribe("AddScore", CupCollected);
    }

    public void SetScore(float points)
    {
        totalTally += points;       //Adds the value to the total
    }

    public float GetScore()
    {
        return totalTally;          //Returns the total score
    }

    public void UpdateText(object[] parameters)
    { 
        scoreText.text = "Score: " + totalTally;        //Sets the UI text with the current score
    }

    public void CupCollected(object[] parameters)
    {
        SetScore((float)parameters[0]);
    }
}
