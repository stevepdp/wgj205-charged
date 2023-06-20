using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance;
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<MusicManager>();
            if (instance == null)
                instance = Instantiate(new GameObject("MusicManager")).AddComponent<MusicManager>();
            return instance;
        }
    }

    const float BGM_VOLUME = 1f;
    const float PITCH_MOD = 1.04f;

    AudioSource audioSource;
    [SerializeField] AudioClip[] trackArray = new AudioClip[1];

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        EnforceSingleInstance();
    }

    void Start()
    {
        SetNextTrackAndPlay(0, true, BGM_VOLUME);
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PauseMusic()
    {
        if (audioSource != null)
            audioSource.Pause();
    }

    public void PlayMusic()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying) return;
            audioSource.pitch = PITCH_MOD;
            audioSource.Play();
        }
    }

    public void SetNextTrackAndPlay(int trackNumber, bool shouldLoop, float vol)
    {
        if (audioSource != null)
        {
            StopMusic();

            audioSource.clip = trackArray[trackNumber];

            if (shouldLoop)
                audioSource.loop = true;
            else
                audioSource.loop = false;

            audioSource.volume = vol;

            PlayMusic();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null)
            audioSource.Stop();
    }
}
