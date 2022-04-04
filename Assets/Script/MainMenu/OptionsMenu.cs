using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public Toggle fullScreenToggle;
    bool inStart = true;

    void Start() {
        //LoadValues();
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
             if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
             {
                 currentResolutionIndex = i;
             }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        if (GameInstance.instance.firstStart) {
            Screen.fullScreen = true;
            GameInstance.instance.firstStart = false;
            GameInstance.instance.actualRes = Screen.currentResolution;
        }

        inStart = false;

        for(int i = 0; i < resolutions.Length;i++)
            if(resolutions[i].width == GameInstance.instance.actualRes.width && resolutions[i].height == GameInstance.instance.actualRes.height) {
                currentResolutionIndex = i;
                resolutionDropdown.value = currentResolutionIndex;
                resolutionDropdown.RefreshShownValue();
                break;
            }

     
        fullScreenToggle.isOn = GameInstance.instance.fullScreen;
        SetFullscreen(GameInstance.instance.fullScreen);
    }

    public void SetResolution(int resolutionIndex) {
        if (inStart)
            return;

        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        GameInstance.instance.actualRes = resolution;
    }


    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
        GameInstance.instance.fullScreen = isFullscreen;
    }

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }

}
