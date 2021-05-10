using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUpBehaviour : MonoBehaviour
{
    public GameObject panel;

    public void close()
    {
        panel.SetActive(false);     //Hides the panel
    }

    public void open()
    {
        panel.SetActive(true);      //Shows the panel
    }
}
