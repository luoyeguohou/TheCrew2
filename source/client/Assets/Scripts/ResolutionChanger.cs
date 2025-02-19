using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionChanger : MonoBehaviour
{
    public TMP_Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        var options = new System.Collections.Generic.List<TMP_Dropdown.OptionData> { };
        foreach (var item in resolutions)
        {
            options.Add(new TMP_Dropdown.OptionData(item.width.ToString() + " * " + item.height.ToString()));
        }
        dropDown.ClearOptions();
        dropDown.AddOptions(options);
        dropDown.onValueChanged.AddListener(OnDropdownValueChanged);

        fullScreen = Screen.fullScreen;
        for (int i = 0; i < resolutions.Length; i++) {
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) {
                dropDown.value = i;
                resolutionIdx = i;
            }
        }
    }

    int resolutionIdx = 0;
    void OnDropdownValueChanged(int index)
    {
        resolutionIdx = index;
    }

    public void ApplyResolution() 
    {
        Resolution[] resolutions = Screen.resolutions;
        Screen.SetResolution(resolutions[resolutionIdx].width, resolutions[resolutionIdx].height, fullScreen);
    }
    bool fullScreen;
    public void Windowed()
    {
        Screen.fullScreen = false;
        fullScreen = false;
    }

    public void FullScreen()
    {
        Screen.fullScreen = true;
        fullScreen = true;
    }
}
