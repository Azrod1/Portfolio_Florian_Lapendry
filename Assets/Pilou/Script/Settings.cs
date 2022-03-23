using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    private Resolution[] resolutions;
    public Dropdown resolutionDropdown;

    public void Start() {
        resolutions = Screen.resolutions;
        List<string> listResolutions = new List<string>();
        int currentResolution = 0;
        int j = 0;
        foreach(Resolution i in resolutions) {
            listResolutions.Add(i.width + " x " + i.height);
            
            if(i.width == Screen.currentResolution.width && i.height == Screen.currentResolution.height) {
                currentResolution = j;
            }
            j++;
        }
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(listResolutions);
        resolutionDropdown.value = currentResolution;
        resolutionDropdown.RefreshShownValue();
        
        audioMixer.GetFloat("Master", out float musicFloatVolume);
        musicSlider.value = musicFloatVolume;
    }

    public void BackToMenu() {
        gameObject.SetActive(false);
    }

    public void SetMusicVolume() {
        audioMixer.SetFloat("Master", musicSlider.value);
    }

    public void SetResolution(int resolutionindex) {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }
}
