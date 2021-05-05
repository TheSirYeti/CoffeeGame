using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject winPanel, losePanel, coffeeSign;

    public void lose()
    {
        coffeeSign.SetActive(false);
        losePanel.SetActive(true);
    }

    public void win()
    {
        coffeeSign.SetActive(false);
        winPanel.SetActive(true);
    }
}
