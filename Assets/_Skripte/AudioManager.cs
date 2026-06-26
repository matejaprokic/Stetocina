using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip uiClick;

    [Header("Music")]
    public AudioClip backgroundMusic;
    float targetMaster = 1f;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("Duplicate destroyed: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

        Debug.Log("AudioManager Start called");
        Debug.Log("Master: " + PlayerPrefs.GetFloat("master", 1f));
        Debug.Log("Music: " + PlayerPrefs.GetFloat("music", 1f));
        Debug.Log("SFX: " + PlayerPrefs.GetFloat("sfx", 1f));

        float masterVolume = PlayerPrefs.GetFloat("master", 1f);
        float musicVolume = PlayerPrefs.GetFloat("music", 1f);
        float sfxVolume = PlayerPrefs.GetFloat("sfx", 1f);

        AudioListener.volume = masterVolume;

        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;

        bool musicEnabled = PlayerPrefs.GetInt("musicEnabled", 1) == 1;

        bool sfxEnabled = PlayerPrefs.GetInt("sfxEnabled", 1) == 1;

        musicSource.mute = !musicEnabled;
        sfxSource.mute = !sfxEnabled;

        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();

    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;

        sfxSource.PlayOneShot(clip);
    }



    public void PlayUIClick()
    {

        PlaySFX(uiClick);
    }



    public void SetMasterVolume(float value)
    {
        AudioListener.volume = value;
        PlayerPrefs.SetFloat("master", value);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("music", value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("sfx", value);
        PlayerPrefs.Save();
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;

        PlayerPrefs.SetInt("musicEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ToggleSFX(bool isOn)
    {
        sfxSource.mute = !isOn;

        PlayerPrefs.SetInt("sfxEnabled", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }


}