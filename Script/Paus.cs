using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paus : MonoBehaviour {

    public static bool paused = false;
    public GameObject play;
    public GameObject loc;
    public GameObject res;

    public void OnPause()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            play.SetActive(true);
            loc.SetActive(true);
            res.SetActive(true);
        }
        
    }

    public void OffPause()
    {
        if(paused)
        {
            Time.timeScale = 1;
            paused = false;
            play.SetActive(false);
            loc.SetActive(false);
            res.SetActive(false);
        }
    }

}
