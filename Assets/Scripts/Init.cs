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
        GameObject[] oldGameManager = GameObject.FindGameObjectsWithTag("GameManager");

        for (int i = 0; i < oldGameManager.Length; i++)
            DestroyImmediate(oldGameManager[i]);


        GameObject[] oldMusicManager = GameObject.FindGameObjectsWithTag("MusicManager");

        for (int i = 0; i < oldMusicManager.Length; i++)
            DestroyImmediate(oldMusicManager[i]);

        GameObject[] oldCoinTotalTracker = GameObject.FindGameObjectsWithTag("CoinTotalTracker");
        // TODO: candidate for the game manager singleton, signaling for the HUD

        for (int i = 0; i < oldCoinTotalTracker.Length; i++)
            DestroyImmediate(oldCoinTotalTracker[i]);
    }

    void StartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
}