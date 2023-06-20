using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameManager _gameManager;
    public Player _player;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _player.OnPlayerDead();
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("dead");
            StartCoroutine(RestartScene());
        }
        else if (other.transform.CompareTag("Box"))
        {
            if (other.transform.GetComponent<StorageBox>().isDeadly)
            {
                Object.Destroy(gameObject);
                if (SoundManager.Instance != null)
                    SoundManager.Instance.PlaySound("dead");
            }
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
