using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    float totalTally;
    public Text scoreText;

    public void setScore(float points)
    {
        totalTally += points;       //Adds the value to the total
    }

    public float getScore()
    {
        return totalTally;          //Returns the total score
    }

    private void Update()
    {
        scoreText.text = "Score: " + totalTally;        //Sets the UI text with the current score
    }
}
