using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTotalTracker : MonoBehaviour
{
    public int _totalGameCoins;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("CoinTotalTracker");

        if (objs.Length > 1)
        {
            Debug.Log("Found more than 1 instance");
            Destroy(objs[1]); // destroy the old one
        }
        else
        {
            Debug.Log("Found no instances, creating new");
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
