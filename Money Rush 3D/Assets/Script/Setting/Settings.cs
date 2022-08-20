using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Settings
{
    // Settings Events:
    public static UnityAction<float> OnMusicVolumeChanged;
    public static UnityAction<float> OnSoundVolumeChanged;

    // private ftelds to hold data:
    private static float _musicVolume;
    private static float _soundVolume;

    // Public Properties :
    public static float MusicVolume
    {
        get { return _musicVolume; }
        set
        {
            _musicVolume = value;
            PlayerPrefs.SetFloat("MusicVolume", value);
            if (OnMusicVolumeChanged != null)
                OnMusicVolumeChanged.Invoke(value);
        }
    }
    public static float SoundVolume
    {
        get { return _soundVolume; }
        set
        {
            _soundVolume = value;
            PlayerPrefs.SetFloat("SoundVolume", value);
            if (OnSoundVolumeChanged != null)
                OnSoundVolumeChanged.Invoke(value);
        }
    }

    static Settings()
    {
        _musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        _soundVolume = PlayerPrefs.GetFloat("SoundVolume", 1);
    }
}
