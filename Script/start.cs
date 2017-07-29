using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

    public GameObject ch_loc;
    public GameObject ch_loc1;


    public void Play()
    {
      
        ch_loc.GetComponent<Animation>().Play();
        gameObject.SetActive(false);
        ch_loc1.SetActive(true);
    }
}
