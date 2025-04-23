using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource MusicSource;

    public AudioClip moveSound;
    public AudioClip buttonSound;
    public AudioClip backgroundMusic;
    
    private bool isMusicOn = true;
    private bool isSoundOn = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        if (MusicSource != null && backgroundMusic != null)
        {
            MusicSource.clip = backgroundMusic;
            MusicSource.loop = true;
            MusicSource.Play();
        }
    }
    
    public void PlayMoveSound()
    {
        if (isSoundOn)
            SFXSource.PlayOneShot(moveSound, 2f);
    }

    public void PlayButtonSound()
    {
        if (isSoundOn)
            SFXSource.PlayOneShot(buttonSound);
    }
    
    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        MusicSource.mute = !isMusicOn;
        Debug.Log("Music is now " + (isMusicOn ? "On" : "Off"));
    }
    
    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        Debug.Log("Sound is now " + (isSoundOn ? "On" : "Off"));
    }
    
    public bool IsMusicOn() { return isMusicOn; }
    public bool IsSoundOn() { return isSoundOn; }
}