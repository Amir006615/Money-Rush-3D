using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [Header("UI References :")]
    [SerializeField] private GameObject satings;
    [SerializeField] private Button CloseButten;
    public GameObject IconSettings;
    [Space]
    [SerializeField] private Slider MusicSlider;
    [SerializeField] private Slider SoundSlider;

    private void Awake()
    {
        // Add Listeners
        CloseButten.onClick.AddListener(Close);

        // Update Ui Wiht Saved values in player prefs
        MusicSlider.value = Settings.MusicVolume;
        SoundSlider.value = Settings.SoundVolume;

        // Add UI elements Listeners :
        MusicSlider.onValueChanged.AddListener(OnMusiceSliderChange);
        SoundSlider.onValueChanged.AddListener(OnSoundeSliderChange);
    }

    private void OnMusiceSliderChange (float value)
    {
        Settings.MusicVolume = value;
    }
    private void OnSoundeSliderChange (float value)
    {
        Settings.SoundVolume = value;
    }

    public void Open()
    {
        satings.SetActive(true);
        IconSettings.SetActive(false);
    }
    public void Close()
    {
        satings.SetActive(false);
        IconSettings.SetActive(true);
    }

    private void OnDestroy()
    {
        // Remove Listeners
        CloseButten.onClick.RemoveListener(Close);

        // Remove UI elements listeners 
        MusicSlider.onValueChanged.RemoveListener(OnMusiceSliderChange);
        SoundSlider.onValueChanged.RemoveListener(OnSoundeSliderChange);
    }
}
