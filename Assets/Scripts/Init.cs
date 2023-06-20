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
        // TODO: candidate for the game manager singleton, signaling for the HUD
        GameObject[] oldCoinTotalTracker = GameObject.FindGameObjectsWithTag("CoinTotalTracker");
        for (int i = 0; i < oldCoinTotalTracker.Length; i++)
            DestroyImmediate(oldCoinTotalTracker[i]);

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