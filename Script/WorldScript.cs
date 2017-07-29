using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScript : MonoBehaviour {

    public static bool EnemyDie = true;
    public static bool AttBool = false;
    public static bool DieChar = false;
    public static int lives = 3;
    public static int stage = 1;
    public static bool restardet = false;
    public static int timedie = 0;
    public static Vector3 lastpos;
    public static float direction = 1f;

    private void Start()
    {
    }

    private void Update()
    {
        
    }
}
