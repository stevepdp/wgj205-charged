using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullscreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Return)) ||
            (Input.GetKey(KeyCode.LeftCommand) && Input.GetKeyDown(KeyCode.Return)))
        {
            if (Screen.fullScreen)
            {
                Screen.SetResolution(1280, 720, false);
            }
            else
            {
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
            }
        }
    }
}
