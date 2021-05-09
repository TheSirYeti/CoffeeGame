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
            levelTime -= Time.deltaTime;
        else levelTime = 0f;

        showTime(levelTime);
    }

    void showTime(float time)
    {
        if(time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timeUI.text = "Time remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float getTimeRemaining()
    {
        return levelTime;
    }
}
