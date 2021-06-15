using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerJumpSound, playerLandSound;
    static AudioSource audioSource;

    void Start()
    {
        playerJumpSound = Resources.Load<AudioClip>("SFX/jump_04");
        playerLandSound = Resources.Load<AudioClip>("SFX/land_04"); //03

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "jump":
                audioSource.PlayOneShot(playerJumpSound);
                break;

            case "land":
                audioSource.PlayOneShot(playerLandSound);
                break;
        }
    }
}
