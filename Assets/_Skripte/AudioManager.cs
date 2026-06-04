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

        AudioListener.volume = PlayerPrefs.GetFloat("master", 1f);
        
        

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
        //Debug.Log("UIClick called");

        //Debug.Log("sfxSource = " + sfxSource);
        //Debug.Log("musicSource = " + musicSource);

        PlaySFX(uiClick);
    }

    //void OnLevelWasLoaded(int level)
    //{
    //    musicSource = GameObject.Find("MusicAudioSource")?.GetComponent<AudioSource>();
    //    sfxSource = GameObject.Find("SFXAudioSource")?.GetComponent<AudioSource>();
    //}

    public void SetMasterVolume(float value)
    {
        targetMaster = value;
        PlayerPrefs.SetFloat("master", value);
    }

    public void SetMusicVolume(float value)
    {
        musicSource.volume = value;
        PlayerPrefs.SetFloat("music", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("sfx", value);
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
    }

    public void ToggleSFX(bool isOn)
    {
        sfxSource.mute = !isOn;
    }

    



}