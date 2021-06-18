using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Game Values
    public int _coinCount;
    public Text coinDisplay;


    void Awake()
    {
        SetGameDefaults();
    }

    void Start()
    {
        
    }

    void LateUpdate()
    {
        coinDisplay.text = _coinCount.ToString();
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