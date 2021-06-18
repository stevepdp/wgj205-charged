using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour { 

    void LateUpdate()
    {
        Switch();
    }

    void Switch() 
    {
        string sceneName = SceneManager.GetActiveScene().name;

        // switch scenes
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Start") || Input.GetButtonDown("Fire1"))
        {
            switch (sceneName)
            {
                case "00_Start":
                    SceneManager.LoadScene("10_Room_01");
                    break;

                // scenes in between progress on room exit

                case "99_End":
                    SceneManager.LoadScene("00_Start");
                    break;
            }
        }
    }
}
