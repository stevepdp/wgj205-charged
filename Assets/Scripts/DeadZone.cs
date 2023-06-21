using System;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public static event Action OnPlayerHitDeadzone;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("dead");
            OnPlayerHitDeadzone?.Invoke();
        }
    }
}
