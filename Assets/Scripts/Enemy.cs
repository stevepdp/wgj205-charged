using System.Collections;
using System.Collections.Generic;
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
            SoundManager.PlaySound("dead");
            StartCoroutine(RestartScene());
        }
        else if (other.transform.CompareTag("Box"))
        {
            if (other.transform.GetComponent<StorageBox>().isDeadly)
            {
                Object.Destroy(gameObject); // kill enemy
                SoundManager.PlaySound("dead");
            }
        }
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
