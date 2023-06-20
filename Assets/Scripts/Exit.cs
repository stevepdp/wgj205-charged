using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Player _player;
    public CoinTotalTracker coinTotalTracker;

    void Start()
    {
        coinTotalTracker = GameObject.Find("CoinTotalTracker").GetComponent<CoinTotalTracker>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player._playerIsExiting = true;
            if (GameManager.Instance != null)
                coinTotalTracker._totalGameCoins += GameManager.Instance.CoinCount;
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("exit");
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
