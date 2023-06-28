using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    void Start()
    {
        CleanupObjects();
        StartGame();
    }

    void CleanupObjects()
    {
        GameObject[] oldFullscreenManager = GameObject.FindGameObjectsWithTag("FullscreenManager");
        for (int i = 0; i < oldFullscreenManager.Length; i++)
            DestroyImmediate(oldFullscreenManager[i]);

        GameObject[] oldGameManager = GameObject.FindGameObjectsWithTag("GameManager");
        for (int i = 0; i < oldGameManager.Length; i++)
            DestroyImmediate(oldGameManager[i]);

        GameObject[] oldMusicManager = GameObject.FindGameObjectsWithTag("MusicManager");
        for (int i = 0; i < oldMusicManager.Length; i++)
            DestroyImmediate(oldMusicManager[i]);

        GameObject[] oldSoundManager = GameObject.FindGameObjectsWithTag("SoundManager");
        for (int i = 0; i < oldSoundManager.Length; i++)
            DestroyImmediate(oldSoundManager[i]);
    }

    void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
}