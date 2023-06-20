using UnityEngine;
using UnityEngine.UI;

public class HUDCoinText : MonoBehaviour
{
    Text coinText;

    void Awake()
    {
        coinText = GetComponent<Text>();
    }

    void Start()
    {
        GetCurrentCoins();
    }

    void OnEnable()
    {
        GameManager.OnCoinValueChange += UpdateCoinCount;
    }

    void OnDisable()
    {
        GameManager.OnCoinValueChange -= UpdateCoinCount;
    }

    void GetCurrentCoins()
    {
        if (GameManager.Instance != null && coinText != null)
            coinText.text = GameManager.Instance.CoinCount.ToString();
    }

    void UpdateCoinCount(int newCoinValue)
    {
        if (coinText != null)
            coinText.text = newCoinValue.ToString();
    }
}