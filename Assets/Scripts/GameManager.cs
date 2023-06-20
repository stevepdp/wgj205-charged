using UnityEngine;
using UnityEngine.UI;

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

    // ENCAPSULATION (getter, setter) -- for Unity Learn: Junior Programmer pathway
    int coinCount;
    public int CoinCount
    {
        get { return coinCount; }
        set { 
            if (value > 0)
                coinCount = value;
            else
                Debug.LogError("Incoming value must be greater than 0");
        }
    }

    [SerializeField] Text coinDisplay;

    void Awake()
    {
        EnforceSingleInstance();
        SetGameDefaults();
    }

    void LateUpdate()
    {
        coinDisplay.text = coinCount.ToString(); // TODO: handle this with events
    }

    void EnforceSingleInstance()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void SetGameDefaults()
    {
        coinCount = 0;
    }
}