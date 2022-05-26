using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private float musicVolume = 1f, sfxVolume = 1f, masterVolume = 1f;

    public static AudioManager audioInstance;

    public AudioSource[] musicAudio;
    public AudioSource[] sfxAudio;

    public float MusicVolume { get => musicVolume;}
    public float SFXVolume { get => sfxVolume; }
    public float MasterVolume { get => masterVolume; }

    private void Awake()
    {
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        audioInstance = this;
        DontDestroyOnLoad(this);

        //Now generate audioSources for music and sfx, if the weren't assigned manualy in inspector
        for (int i = 0; i < musicAudio.Length; i++) 
        {
            if (musicAudio[i] == null)
            {
                musicAudio[i] = gameObject.AddComponent<AudioSource>();
                
            }
        }

        for (int i = 0; i < sfxAudio.Length; i++)
        {
            if (sfxAudio[i] == null)
                sfxAudio[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    //void Start()
    //{
    //    SettingsManager.LoadSettings();

    //    musicVolume = SettingsManager.MusicVolume;
    //    musicVolumeSlider.value = musicVolume;
    //    musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(musicVolumeSlider.value); });

    //    sfxVolume = SettingsManager.SoundVolume;
    //    sfxVolumeSlider.value = sfxVolume;
    //    sfxVolumeSlider.onValueChanged.AddListener(delegate { OnSfxVolumeChange(sfxVolumeSlider.value); });

    //    if (SettingsManager.IsMuted)
    //    {
    //        MuteAllSounds();
    //    }

    //    UpdateAudio();
    //}

    void UpdateAudio()
    {
        foreach (var music in musicAudio)
        {
            music.volume = musicVolume*masterVolume;
        }

        foreach (var audio in sfxAudio)
        {
            audio.volume = sfxVolume*masterVolume;
        }
    }

    public void OnMasterVolumeChange(float vol)
    {
        masterVolume = vol;
        UpdateAudio();
    }

    public void OnMusicVolumeChange(float vol)
    {
        musicVolume = vol;
        //SettingsManager.MusicVolume = musicVolume;
        //SettingsManager.SaveSettings();
        UpdateAudio();
    }

    public void OnSfxVolumeChange(float vol)
    {
        sfxVolume = vol;
        //SettingsManager.SoundVolume = sfxVolume;
        //SettingsManager.SaveSettings();
        UpdateAudio();
    }

    private void OnApplicationFocus(bool inFocus)
    {
        //if (!inFocus)
        //{
        //    SettingsManager.SaveSettings();
        //}
    }

    private void MuteSFX()
    {
        foreach (var audio in sfxAudio)
        {
            audio.mute = true;
        }
    }

    private void UnmuteSFX()
    {
        foreach (var audio in sfxAudio)
        {
            audio.mute = false;
        }
    }

    private void MuteMusic()
    {
        foreach (var music in musicAudio)
        {
            music.mute = true;
        }
    }

    private void UnmuteMusic()
    {
        foreach (var music in musicAudio)
        {
            music.mute = false;
        }
    }

    public void MuteAllSounds()
    {
        MuteMusic();
        MuteSFX();
        //SettingsManager.IsMuted = true;
        //SettingsManager.SaveSettings();
    }

    public void UnmuteAllSounds()
    {
        UnmuteMusic();
        UnmuteSFX();
        //SettingsManager.IsMuted = false;
        //SettingsManager.SaveSettings();
    }

    public AudioSource GetAudioSource()
    {
        foreach (var audioS in AudioManager.audioInstance.sfxAudio)
        {
            if (audioS.clip == null) //Search for free audio track
                return audioS;
        }
        //Return first if we can't find any 
        return AudioManager.audioInstance.sfxAudio[0];
    }

    public AudioSource GetMusicSource()
    {
        foreach(var musicS in AudioManager.audioInstance.musicAudio)
        {
            if (musicS.clip == null) //Search for free music track
                return musicS;
        }
        //Return first if we can't find any 
        return AudioManager.audioInstance.musicAudio[0];
    }
}