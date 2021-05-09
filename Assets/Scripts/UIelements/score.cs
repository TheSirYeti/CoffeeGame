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
        totalTally += points;
    }

    public float getScore()
    {
        return totalTally;
    }

    private void Update()
    {
        scoreText.text = "Score: " + totalTally;
    }
}
