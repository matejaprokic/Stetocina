using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public Toggle musicToggle;
    public Toggle sfxToggle;

    void Start()
    {
        if (!UIManager.startGameDirectly)
        {
            ResetToDefault();
        }
        else
        {
            Refresh();
        }
    }

    public void Refresh()
    {
        masterSlider.value =
            PlayerPrefs.GetFloat("master", 1f);

        musicSlider.value =
            PlayerPrefs.GetFloat("music", 1f);

        sfxSlider.value =
            PlayerPrefs.GetFloat("sfx", 1f);

        musicToggle.isOn =
            PlayerPrefs.GetInt("musicEnabled", 1) == 1;

        sfxToggle.isOn =
            PlayerPrefs.GetInt("sfxEnabled", 1) == 1;
    }

    void OnEnable()
    {
        Refresh();
    }

    public void OnMusicSliderChanged(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }

    public void OnMasterSliderChanged(float value)
    {
        AudioManager.Instance.SetMasterVolume(value);
    }

    public void OnSFXSliderChanged(float value)
    {
        AudioManager.Instance.SetSFXVolume(value);
    }

    public void OnMusicToggleChanged(bool value)
    {
        AudioManager.Instance.ToggleMusic(value);
    }

    public void OnSFXToggleChanged(bool value)
    {
        AudioManager.Instance.ToggleSFX(value);
    }

    public void ResetToDefault()
    {
        masterSlider.value = 1f;
        musicSlider.value = 1f;
        sfxSlider.value = 1f;

        musicToggle.isOn = true;
        sfxToggle.isOn = true;

        AudioManager.Instance.SetMasterVolume(1f);
        AudioManager.Instance.SetMusicVolume(1f);
        AudioManager.Instance.SetSFXVolume(1f);

        PlayerPrefs.SetFloat("master", 1f);
        PlayerPrefs.SetFloat("music", 1f);
        PlayerPrefs.SetFloat("sfx", 1f);

        PlayerPrefs.SetInt("musicEnabled", 1);
        PlayerPrefs.SetInt("sfxEnabled", 1);

        PlayerPrefs.Save();
    }
}
