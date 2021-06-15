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

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "jump_01":
                audioSource.PlayOneShot(playerJumpSound);
                break;
        }
    }
}
