using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public void Rest()
    {
        SceneManager.LoadScene("Roi_Lvl_1");
        Time.timeScale = 1;
        WorldScript.DieChar = false;
        WorldScript.timedie = 1;
        if (WorldScript.lives == 0 || Paus.paused)
        {
            WorldScript.lives = 3;
            WorldScript.stage = 1;
            WorldScript.timedie = 0;
        }
        Paus.paused = false;
        
        WorldScript.EnemyDie = true;
        
    }
}
