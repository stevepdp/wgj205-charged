using UnityEngine;
using UnityEngine.UI;

public class HUDCoinText : MonoBehaviour
{
    Text coinText;

    void Awake()
    {
        coinText = GetComponent<Text>();
    }

    void OnEnable()
    {
        GameManager.OnCoinValueChange += UpdateCoinCount;
    }

    void OnDisable()
    {
        GameManager.OnCoinValueChange -= UpdateCoinCount;
    }

    void UpdateCoinCount(int newCoinValue)
    {
        if (coinText != null)
            coinText.text = newCoinValue.ToString();
    }
}