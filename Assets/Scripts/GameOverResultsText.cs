using UnityEngine;
using UnityEngine.UI;

public class TotalGameCoinsReadout : MonoBehaviour
{
    Text totalGameCoinsText;

    void Awake()
    {
        totalGameCoinsText = GetComponent<Text>();
    }

    void Start()
    {
        StopMusic();
        SetFinalText();
    }

    void SetFinalText()
    {
        if (GameManager.Instance != null && totalGameCoinsText != null)
        {
            if (GameManager.Instance.CoinCount == 0)
                totalGameCoinsText.text = "You got through without collecting any coins.\n\nImagine myself awarding you\nwith a blue gem ;-)";
            else if (GameManager.Instance.CoinCount == 1)
                totalGameCoinsText.text = "You collected: " + GameManager.Instance.CoinCount.ToString() + " coin.\n\nThat's not a lotta coin!";
            else if (GameManager.Instance.CoinCount >= 2 && GameManager.Instance.CoinCount <= 10)
                totalGameCoinsText.text = "You collected: " + GameManager.Instance.CoinCount.ToString() + " coins!\n\nThat's a lotta coin!";
            else if (GameManager.Instance.CoinCount >= 11)
                totalGameCoinsText.text = "You collected: " + GameManager.Instance.CoinCount.ToString() + " coins!\n\nThat's a whole lotta coin!";
        }
    }

    void StopMusic()
    {
        if (MusicManager.Instance != null)
            MusicManager.Instance.StopMusic();
    }
}
