using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Black_Screen : MonoBehaviour {

    public bool animplay = false;
    public GameObject res;
    public GameObject rest;
    public GameObject spawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(WorldScript.stage == 2)
        {
            
        }

        if (!animplay && WorldScript.DieChar == true)
        {
            GetComponent<Animation>().Play();
            animplay = true;
            WorldScript.lives = WorldScript.lives - 1;
        }
        if (WorldScript.DieChar && !GetComponent<Animation>().isPlaying)
        {
            Time.timeScale = 0;
            if (WorldScript.lives > 0) rest.GetComponent<Restart>().Rest();
            else if (WorldScript.lives == 0)
            {
                res.SetActive(true);
                
            }
        }
        
    }
}
