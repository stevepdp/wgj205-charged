using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerDeadSound,
                            playerJumpSound,
                            playerLandSound;

    static AudioSource audioSource;

    void Start()
    {
        playerDeadSound = Resources.Load<AudioClip>("SFX/dead_01");
        playerJumpSound = Resources.Load<AudioClip>("SFX/jump_04");
        playerLandSound = Resources.Load<AudioClip>("SFX/land_04");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "dead":
                audioSource.PlayOneShot(playerDeadSound);
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