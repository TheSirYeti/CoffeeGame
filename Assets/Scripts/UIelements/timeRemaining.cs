using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeRemaining : MonoBehaviour
{
    [SerializeField]private float levelTime;
    public Text timeUI;

    private void Update()
    {
        if (levelTime > 0f)
            levelTime -= Time.deltaTime;        //If there's still time, keep counting down
        else levelTime = 0f;                    

        ShowTime(levelTime);
    }

    void ShowTime(float time)
    {
        if(time < 0)
        {
            time = 0;
            EventManager.Trigger("Lose");
        }

        float minutes = Mathf.FloorToInt(time / 60);        //We divide by 60 to get the total minutes remaining
        float seconds = Mathf.FloorToInt(time % 60);        //We do the module calculation to get the amount of seconds it the minute

        if (time <= 15)
            timeUI.color = Color.red;
        timeUI.text = "Time remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);    //We show the current time in the MINUTES:SECONDS format
    }

    public float GetTimeRemaining()
    {
        return levelTime;
    }
}
