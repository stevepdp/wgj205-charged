using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource _audioSource;
    //public Transform musicCredit;
    public AudioClip[] _trackList = new AudioClip[1];

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        _audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        SetNextTrackAndPlay(0, true, 1f); // this prefab is instanciated on notice. So it starts with track 0.
    }

    public void PauseMusic()
    {
        _audioSource.Pause();
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.pitch = 1.04f;
        _audioSource.Play();
        //Instantiate(musicCredit);
    }

    public void SetNextTrackAndPlay(int trackNumber, bool shouldLoop, float vol)
    {
        StopMusic();

        _audioSource.clip = _trackList[trackNumber];

        if (shouldLoop)
        {
            _audioSource.loop = true;
        }
        else
        {
            _audioSource.loop = false;
        }

        _audioSource.volume = vol;

        PlayMusic();
        // trigger in-game credit if not [0]
    }

    public void StopMusic()
    {
        Debug.Log("Music Manager: Stop message received");
        _audioSource.Stop();
    }
}
