using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopUp : MonoBehaviour
{
    public GameObject panel;
    public Text scoreText;

    private void Start()
    {
        EventManager.Subscribe("UpdateScoreText", UpdateText);
    }

    public void close()
    {
        panel.SetActive(false);     //Hides the panel
    }

    public void open()
    {
        panel.SetActive(true);      //Shows the panel
        scoreText.text = "TOTAL SCORE: " + TotalScore.instance.GetScore();
    }

    public void UpdateText(object[] parameters)
    {
        scoreText.text = "TOTAL SCORE: " + TotalScore.instance.GetScore();
    }
}
