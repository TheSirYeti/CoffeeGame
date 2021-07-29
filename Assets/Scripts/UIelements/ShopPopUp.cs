using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPopUp : MonoBehaviour
{
    public GameObject panel;
    public Text scoreText;

    public List<Button> buyButtons;
    public List<Button> equipButtons;

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

        for(int i = 0; i < buyButtons.Count; i++)
        {
            if (ShopSystem.instance.unlockedItems[i])
            {
                buyButtons[i].interactable = false;
                equipButtons[i].interactable = true;
            } else
            {
                buyButtons[i].interactable = true;
                equipButtons[i].interactable = false;
            }
        }
    }

    public void UpdateText(object[] parameters)
    {
        scoreText.text = "TOTAL SCORE: " + TotalScore.instance.GetScore();
    }

    public void BuySkin(int index)
    {
        if (TotalScore.instance.GetScore() - ShopSystem.instance.items[index] >= 0)
        {
            SoundManager.instance.PlaySound(SoundID.BUY);
            ShopSystem.instance.unlockedItems[index] = true;
            TotalScore.instance.RemoveScore(ShopSystem.instance.items[index]);
            EventManager.Trigger("UpdateScoreText");
            buyButtons[index].interactable = false;
            equipButtons[index].interactable = true;
        }
        else SoundManager.instance.PlaySound(SoundID.DENIED);
    }

    public void EquipSkin(int index)
    {
        if (ShopSystem.instance.unlockedItems[index])
        {
            TotalScore.instance.SetCupIndexValue(index);
            SoundManager.instance.PlaySound(SoundID.BUY);
        }
        else SoundManager.instance.PlaySound(SoundID.DENIED);
    }
}
