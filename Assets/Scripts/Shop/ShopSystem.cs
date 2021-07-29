using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    public List<float> items;
    public List<bool> unlockedItems;
    public List<Button> buyButtons;
    public List<Button> equipButtons;
    public static ShopSystem instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BuySkin(int index)
    {
        if(TotalScore.instance.GetScore() - items[index] >= 0)
        {
            SoundManager.instance.PlaySound(SoundID.BUY);
            unlockedItems[index] = true;
            TotalScore.instance.RemoveScore(items[index]);
            EventManager.Trigger("UpdateScoreText");
            buyButtons[index].interactable = false;
            equipButtons[index].interactable = true;
        }
        else SoundManager.instance.PlaySound(SoundID.DENIED);
    }

    public void EquipSkin(int index)
    {
        if (unlockedItems[index])
        {
            TotalScore.instance.SetCupIndexValue(index);
            SoundManager.instance.PlaySound(SoundID.BUY);
        }
        else SoundManager.instance.PlaySound(SoundID.DENIED);
    }
}
