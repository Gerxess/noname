using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float speed = 7f;
    private float jumpForce = 200f;
    
    public Rigidbody2D rigibody;
    public CollisionDetectionMode2D collisionDetectionMode;
    
    bool facingRight = true;
   
   // public static Vector3 posE1, posE2;
    void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        WorldScript.lastpos = transform.position;
        if(!WorldScript.DieChar)
        {
            Vector3 direction2 = transform.right * WorldScript.direction;

            transform.Translate(direction2 * Time.deltaTime * speed);
            //rigibody.velocity = new Vector2(speed * direction, rigibody.velocity.y);
            if (!facingRight && WorldScript.direction < 0)
                Flip();
            else if (facingRight && WorldScript.direction > 0)
                Flip();
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall1")
        {
            WorldScript.direction = -WorldScript.direction;
        }
        else if (collision.gameObject.name == "Wall2")
        {
            WorldScript.direction = -WorldScript.direction;
        }
        else if (collision.gameObject.name == "floar")
        {
            rigibody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BULLET")
        {
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag("BULLET"));
            if (WorldScript.stage == 1)
            {
                WorldScript.stage = WorldScript.stage + 1;
                WorldScript.EnemyDie = true;
            }
            if (WorldScript.stage == 2)
            {
                if (WorldScript.timedie == 4)
                {
                    WorldScript.stage = WorldScript.stage + 1;
                    WorldScript.timedie = 0;
                }
                WorldScript.timedie++;
                WorldScript.EnemyDie = true;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
