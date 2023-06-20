using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<SoundManager>();
            if (instance == null)
                instance = Instantiate(new GameObject("SoundManager")).AddComponent<SoundManager>();
            return instance;
        }
    }

    AudioClip coinGetSound,
              playerDeadSound,
              playerExitSound,
              playerJumpSound,
              playerLandSound;

    AudioSource audioSource;

    void Awake()
    {
        EnforceSingleInstance();

        coinGetSound    = Resources.Load<AudioClip>("SFX/coin_02");
        playerDeadSound = Resources.Load<AudioClip>("SFX/dead_01");
        playerExitSound = Resources.Load<AudioClip>("SFX/exit_04");
        playerJumpSound = Resources.Load<AudioClip>("SFX/jump_04");
        playerLandSound = Resources.Load<AudioClip>("SFX/land_04");

        audioSource = GetComponent<AudioSource>();
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "coin":
                audioSource.PlayOneShot(coinGetSound);
                break;

            case "dead":
                audioSource.PlayOneShot(playerDeadSound);
                break;

            case "exit":
                audioSource.PlayOneShot(playerExitSound);
                break;

            case "jump":
                audioSource.PlayOneShot(playerJumpSound);
                break;

            case "land":
                audioSource.PlayOneShot(playerLandSound);
                break;
        }
    }
}