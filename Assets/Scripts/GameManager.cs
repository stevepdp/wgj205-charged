using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<GameManager>();
            if (instance == null)
                instance = Instantiate(new GameObject("GameManager")).AddComponent<GameManager>();
            return instance;
        }
    }

    public static event Action<int> OnCoinValueChange;

    // ENCAPSULATION (getter, setter) -- for Unity Learn: Junior Programmer pathway
    int coinCount;
    public int CoinCount
    {
        get { return coinCount; }
        set { 
            if (value > 0)
            {
                coinCount = value;
                OnCoinValueChange?.Invoke(coinCount);
            }
            else
            {
                Debug.LogError("Incoming value must be greater than 0");
            }
        }
    }

    void Awake()
    {
        EnforceSingleInstance();
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
