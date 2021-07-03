using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuSettings : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Dropdown MyResolutions;

    [SerializeField]
    private AudioMixer MyAudioMixer;


    private void Start()
    {
        CreateResolutionList();
    }

    private void CreateResolutionList()
    {
        Resolution[] resolutions = Screen.resolutions;

        MyResolutions.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < Screen.resolutions.Length; i++)
        {
            Resolution r = Screen.resolutions[i];

            string option = r.width + "x" + r.height;
            options.Add(option);

            if(r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        MyResolutions.AddOptions(options);
        MyResolutions.value = currentResolutionIndex;
        MyResolutions.RefreshShownValue();
    }


    public void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(Screen.resolutions[resolutionIndex].width, Screen.resolutions[resolutionIndex].height, Screen.fullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }


    public void SetVolumeMaster(float volume)
    {
        MyAudioMixer.SetFloat("Volume_Master", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        MyAudioMixer.SetFloat("Volume_Music", volume);
    }

    public void SetVolumeSFX(float volume)
    {
        MyAudioMixer.SetFloat("Volume_SFX", volume);
    }
}
