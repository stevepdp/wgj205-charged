using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.CoinCount++;
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("coin");
            Destroy(gameObject);
        }
    }
}
