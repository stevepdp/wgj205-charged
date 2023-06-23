using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    AudioClip coinGetSound,
              playerDeadSound,
              playerExitSound,
              playerJumpSound,
              playerLandSound;

    AudioSource audioSource;

    public override void Awake()
    {
        coinGetSound    = Resources.Load<AudioClip>("SFX/coin_02");
        playerDeadSound = Resources.Load<AudioClip>("SFX/dead_01");
        playerExitSound = Resources.Load<AudioClip>("SFX/exit_04");
        playerJumpSound = Resources.Load<AudioClip>("SFX/jump_04");
        playerLandSound = Resources.Load<AudioClip>("SFX/land_04");

        audioSource = GetComponent<AudioSource>();
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