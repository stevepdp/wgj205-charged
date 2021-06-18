using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateCleaner : MonoBehaviour
{
    private void Start()
    {
        GameObject[] gObjs = GameObject.FindGameObjectsWithTag("GameManager");

        if (gObjs.Length > 0)
        {
            //Destroy(this.gameObject);
            Destroy(gObjs[0]); // destroy the old one
            Debug.Log("Destroyed old game manager");
        }

        GameObject[] cObjs = GameObject.FindGameObjectsWithTag("CoinTotalTracker");

        if (cObjs.Length > 0)
        {
            //Destroy(this.gameObject);
            Destroy(cObjs[0]); // destroy the old one
            Debug.Log("Destroyed old coin tracker");
        }
    }
}
