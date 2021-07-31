using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP Final - Juan Pablo Rshaid
public class score : MonoBehaviour
{
    float totalTally;
    public Text scoreText;

    private void Start()
    {
        EventManager.Subscribe("AddCup", UpdateText);
        EventManager.Subscribe("AddScore", CupCollected);
        EventManager.Subscribe("Win", AddToTotal);
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
        UpdateText(null);
    }

    public void AddToTotal(object[] parameters)
    {
        //EventManager.Trigger("AddTotalScore", totalTally);
        TotalScore.instance.AddScore(totalTally);
    }
}
