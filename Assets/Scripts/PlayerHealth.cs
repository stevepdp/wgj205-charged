using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerIsDead;

    const byte RESTART_TIMEOUT = 2;

    Animator animator;
    bool isAlive = false;
    [SerializeField] int hp = 1;

    public bool IsAlive
    {
        get { 
            return isAlive;
        }
    }

    public int HP { 
        get { 
            return hp;
        }
        set {
            if (value <= 0)
                return;
            else
                hp = value;
        }
    }

    void OnEnable()
    {
        DeadZone.OnPlayerHitDeadzone += Kill;
        Enemy.OnHitByEnemy += DeductHealth;
    }

    void OnDisable()
    {
        DeadZone.OnPlayerHitDeadzone -= Kill;
        Enemy.OnHitByEnemy -= DeductHealth;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void DeductHealth()
    {
        if (hp > 0)
            hp--;
        HealthCheck();
    }

    void HealthCheck()
    {
        if (hp <= 0)
        {
            isAlive = false;
            PlayerDead();
        }
    }

    void Kill()
    {
        hp = 0;
        PlayerDead();
    }

    void PlayerDead()
    {
        if (animator != null)
            animator.SetTrigger("Dead");
        OnPlayerIsDead?.Invoke();
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(RESTART_TIMEOUT);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}