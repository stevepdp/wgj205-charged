using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Player _player;
    public GameManager _gameManager;
    public CoinTotalTracker coinTotalTracker;

    private void Start()
    {
        coinTotalTracker = GameObject.Find("CoinTotalTracker").GetComponent<CoinTotalTracker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player._playerIsExiting = true;
            coinTotalTracker._totalGameCoins += _gameManager._coinCount;
            SoundManager.PlaySound("exit");
            StartCoroutine(NextScene());
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
