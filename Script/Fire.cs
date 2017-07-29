using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    
    public Rigidbody2D bullet;
    public float tbf = 1f;
    public float ttnf = 0f;

    public void Fir()
    {
        if (ttnf < 0)
        {
            Vector3 position = transform.position; position.y += 4F;
            Rigidbody2D clone = Instantiate(bullet, position, Quaternion.identity) as Rigidbody2D;
            ttnf = tbf;
            WorldScript.AttBool = true;
        }
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ttnf -= Time.deltaTime;

    }
}
