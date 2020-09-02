using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    #region |Variables
    [Header("Audio")]
    public AudioMixer audioMixer;
    public TextMeshProUGUI masterVolDisplay;
    public TextMeshProUGUI musicVolDisplay;
    public TextMeshProUGUI sfxVolDisplay;

    float masterVolume = 0;
    bool masterIsMuted = false;
    float musicVolume = 0;
    bool musicIsMuted = false;
    float sfxVolume = 0;
    bool sfxIsMuted = false;

    [Header("Resolution")]
    public TMP_Dropdown resDropdown;
    //*PRIVATE//
    Resolution[] resolutions;
    #endregion

    #region |Setup
    private void Start()
    {
        #region ||Resolution Dropdown Setup
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        int currentResIndex = 0;

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResIndex = i;
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
        #endregion
    }
    #endregion

    #region |Resolution
    public void SetResolution(int resIndex)
    {
        Click();
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        // print (Screen.currentResolution);
    }
    #endregion

    #region |Fullscreen
    public void SetFullscreen(bool goFullscreen)
    {
        Click();
        Screen.fullScreen = goFullscreen;
        //print (Screen.fullScreen);
    }
    #endregion

    #region |Quality
    public void SetQuality(int qualityIndex)
    {
        Click();
        QualitySettings.SetQualityLevel(qualityIndex);
        // print (QualitySettings.GetQualityLevel ());
    }
    #endregion

    #region |Volume
    #region ||Master Volume
    public void MasterVolSlider(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);

        volume += 80;
        masterVolDisplay.text = volume.ToString() + "%";

        masterVolume = volume;
    }

    public void MuteMasterVol(bool mute)
    {
        sfxIsMuted = mute;
        if (sfxIsMuted == true)
        {
            audioMixer.GetFloat("MasterVolume", out masterVolume);
            audioMixer.SetFloat("MasterVolume", -80);
            masterVolDisplay.text = "0%";
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", masterVolume);
            masterVolDisplay.text = (masterVolume + 80).ToString() + "%";
        }
    }
    #endregion

    #region ||Music Volume
    public void MusicVolSlider(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);

        volume += 80;
        musicVolDisplay.text = volume.ToString() + "%";

        musicVolume = volume;
    }

    public void MuteMusicVol(bool mute)
    {
        sfxIsMuted = mute;
        if (sfxIsMuted == true)
        {
            audioMixer.GetFloat("MusicVolume", out musicVolume);
            audioMixer.SetFloat("MusicVolume", -80);
            musicVolDisplay.text = "0%";
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", musicVolume);
            musicVolDisplay.text = (musicVolume + 80).ToString() + "%";
        }
    }
    #endregion

    #region ||SFX Volume
    public void SfxVolSlider(float volume)
    {
        audioMixer.SetFloat("SfxVolume", volume);

        volume += 80;
        sfxVolDisplay.text = volume.ToString() + "%";

        sfxVolume = volume;
    }

    public void MuteSfxVol(bool mute)
    {
        sfxIsMuted = mute;
        if (sfxIsMuted == true)
        {
            audioMixer.GetFloat("SfxVolume", out sfxVolume);
            audioMixer.SetFloat("SfxVolume", -80);
            sfxVolDisplay.text = "0%";
        }
        else
        {
            audioMixer.SetFloat("SfxVolume", sfxVolume);
            sfxVolDisplay.text = (sfxVolume + 80).ToString() + "%";
        }
    }
    #endregion
    #endregion

    void Click()
    {
        FindObjectOfType<AudioManager>().Play("Click01");
    }
}