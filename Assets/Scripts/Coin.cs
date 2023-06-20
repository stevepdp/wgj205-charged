using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager._coinCount++;
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("coin");
            Destroy(gameObject);
        }
    }
}
