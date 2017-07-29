using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour {

   
    private float speed = 6f;
    private float jumpForce = 115.0f;
    private bool isGrounded = false;
    bool facingRight = true;
    

    public GameObject bs;

    private Rigidbody2D rigibody;
    private Animator animator;
    


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }


    private void Awake()
    {
        rigibody = GetComponentInChildren<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(!WorldScript.DieChar)
        { 
        State = CharState.Idle;

        if (Input.accelerationEventCount > 0) Run();

        if (WorldScript.AttBool) State = CharState.Attack;
        if (!isGrounded) State = CharState.Jump;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) WorldScript.AttBool = false;
        }
        
        

    }

    private void FixedUpdate()
    {
        CheckGround();
    }

  /*  public void Attack()
    {
       State = CharState.Attack;
       AttBool = true;
      

    }*/

    
    public void Jump()
    {
         if (isGrounded)
        {
            rigibody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            State = CharState.Jump;
        }

    } 

    private void Run()
    {
        Vector3 direction2 = transform.right * Input.acceleration.x;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction2, speed * Time.deltaTime);

        if (isGrounded) State = CharState.Run;

        if (Input.acceleration.x > 0 && !facingRight)
            Flip();
        else if (Input.acceleration.x < 0 && facingRight)
            Flip();
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3F);

        isGrounded = colliders.Length > 1;
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ENEMY")
        {
            //Time.timeScale = 0;
            WorldScript.DieChar = true;
            bs.SetActive(true);
        }
    }

}
public enum CharState
{
    Idle,
    Run,
    Jump,
    Attack
}