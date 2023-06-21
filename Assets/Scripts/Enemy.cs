using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action OnHitByEnemy;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            OnHitByEnemy?.Invoke();
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("dead");
        }
        else if (other.transform.CompareTag("Box"))
        {
            if (other.transform.GetComponent<StorageBox>().isDeadly)
            {
                if (SoundManager.Instance != null)
                    SoundManager.Instance.PlaySound("dead");
                Destroy(gameObject);
            }
        }
    }
}
