using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject small;
    public GameObject middle;
    public GameObject big;
    
    // Use this for initialization
    void Start ()
    {
        if (WorldScript.stage == 1)
        {
            Vector3 pos = transform.position;
            Instantiate(small, pos, Quaternion.identity);
            WorldScript.EnemyDie = false;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (WorldScript.EnemyDie && WorldScript.stage == 2)
        {
            Debug.Log(WorldScript.timedie);
            if (WorldScript.timedie == 1)
            {
                
                Vector3 pos = transform.position;
                Instantiate(middle, pos, Quaternion.identity);
                WorldScript.EnemyDie = false;
            }
            if (WorldScript.timedie == 2)
            {
                Instantiate(small, WorldScript.lastpos + new Vector3(-2, 1, 0), Quaternion.identity);
                WorldScript.direction = -WorldScript.direction;
                Instantiate(small, WorldScript.lastpos + new Vector3(2, 1 , 0), Quaternion.identity);
                WorldScript.EnemyDie = false;
                
            }

        }
        if (WorldScript.EnemyDie && WorldScript.stage == 3)
        {
            Vector3 pos = transform.position;
            Instantiate(big, pos, Quaternion.identity);
            WorldScript.EnemyDie = false;
            

        }
    }
}
