using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TP Final - Juan Pablo Rshaid
public class JetPackUI : MonoBehaviour
{
    public Image ui;

    private void Start()
    {
        EventManager.Subscribe("HideJetPackUI", HideImage);
    }
    void HideImage(object[] parameters)
    {
        ui.enabled = false;
    }
}
