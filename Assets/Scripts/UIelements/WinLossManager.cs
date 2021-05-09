using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLossManager : MonoBehaviour
{
    public GameObject conditionPanel;
    public List<GameObject> otherUIElements;

    void showConditionPanel()
    {
        foreach(GameObject g in otherUIElements)
        {
            g.SetActive(false);
        }

        conditionPanel.SetActive(true);
    }
}
