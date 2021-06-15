using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Game Values
    private int _coinCount;

    // Game States

    // Input Values
    private float _horizontalInput;
    private float _verticalInput;

    // IEnumerators


    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        SetGameDefaults();
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
    }

   public void OnRoomRestart()
    {
    }

    public void OnGameOver()
    {
        Debug.Log("GameOver condition met. Going to end.");
        SceneManager.LoadScene("99_End");
    }

    void SetGameDefaults()
    {
        _coinCount = 0;
    }
}