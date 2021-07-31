using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    public Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public bool isFullscreen;

    private void Start()
    {
        List<string> options = new List<string>();

        int currentResolution = 0;

        resolutions = Screen.resolutions;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string res = resolutions[i].width + " x " + resolutions[i].height + " - @" + resolutions[i].refreshRate + "Hz"; 
            options.Add(res);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution res = resolutions[index];
        Screen.SetResolution(res.width, res.height, isFullscreen);
    }

    public void SetFullscreen(bool screenType)
    {
        isFullscreen = screenType;
        Screen.fullScreen = screenType;
    }
}
