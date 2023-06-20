using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (SoundManager.Instance != null)
                SoundManager.Instance.PlaySound("dead");
            other.GetComponent<Player>().OnPlayerDead();
            StartCoroutine(PlayerDead());
        }
    }

    IEnumerator PlayerDead()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
