using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;

    void Start()
    {
        masterVolumeSlider.value = AudioManager.audioInstance.MasterVolume;
        masterVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.audioInstance.OnMasterVolumeChange(masterVolumeSlider.value); });

        musicVolumeSlider.value = AudioManager.audioInstance.MusicVolume;
        musicVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.audioInstance.OnMusicVolumeChange(musicVolumeSlider.value); });

        sfxVolumeSlider.value = AudioManager.audioInstance.SFXVolume;
        sfxVolumeSlider.onValueChanged.AddListener(delegate { AudioManager.audioInstance.OnSfxVolumeChange(sfxVolumeSlider.value); });
    }

    private void MuteAll()
    {
        AudioManager.audioInstance.MuteAllSounds();
    }

    private void UnmuteAll()
    {
        AudioManager.audioInstance.UnmuteAllSounds();
    }

    //public void SwapMute()
    //{
    //    if (SettingsManager.IsMuted)
    //        UnmuteAll();
    //    else
    //        MuteAll();
    //}
}
