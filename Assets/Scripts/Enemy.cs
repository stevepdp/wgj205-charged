using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    const byte RESTART_TIMEOUT = 2;

    Player player;

    void Awake()
    {
        player = FindFirstObjectByType<Player>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (player != null)
                player.OnPlayerDead();
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("dead");
            StartCoroutine(RestartScene());
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

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(RESTART_TIMEOUT);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
