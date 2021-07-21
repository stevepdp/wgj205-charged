using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalGameCoinsReadout : MonoBehaviour
{
    public Text totalGameCoinsText;
    public CoinTotalTracker coinTotalTracker;
    private GameObject _musicManager;

    private void Awake()
    {
        _musicManager = GameObject.FindGameObjectWithTag("MusicManager");
    }
    private void Start()
    {
        if (_musicManager != null) _musicManager.GetComponent<MusicManager>().StopMusic();
        coinTotalTracker = GameObject.Find("CoinTotalTracker").GetComponent<CoinTotalTracker>();
    }

    void LateUpdate()
    {
        if (coinTotalTracker._totalGameCoins == 0)
        {
            totalGameCoinsText.text = "You got through without collecting any coins.\n\nImagine myself awarding you\nwith a blue gem ;-)";
        }
        else if (coinTotalTracker._totalGameCoins == 1)
        {
            totalGameCoinsText.text = "You collected: " + coinTotalTracker._totalGameCoins.ToString() + " coin.\n\nThat's not a lotta coin!";
        }
        else if (coinTotalTracker._totalGameCoins >= 2 && coinTotalTracker._totalGameCoins <= 10)
        {
            totalGameCoinsText.text = "You collected: " + coinTotalTracker._totalGameCoins.ToString() + " coins!\n\nThat's a lotta coin!";
        }
        else if (coinTotalTracker._totalGameCoins >= 11)
        {
            totalGameCoinsText.text = "You collected: " + coinTotalTracker._totalGameCoins.ToString() + " coins!\n\nThat's a whole lotta coin!";
        }
        
    }
}
