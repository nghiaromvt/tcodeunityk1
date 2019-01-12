using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour {
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer render;
    public float speed;
    public float jumpForce;

    private bool attack;
    private int jumpCounter;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        jumpCounter = 2;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement();
	}

    private void Movement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        var vel = myBody.velocity;
        if(xAxis<0)
        {
            vel.x = -speed ;
            myBody.velocity = vel;
            anim.SetBool("IsWalking", true);
            render.flipX = true;
        }
        else if(xAxis>0)
        {
            vel.x = speed;
            myBody.velocity = vel;
            anim.SetBool("IsWalking", true);
            render.flipX = false;
        }
        else if(xAxis==0)
        {
            anim.SetBool("IsWalking", false);
        }
        
        if(Input.GetKeyDown(KeyCode.Space)&&canJump(jumpCounter))
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            attack = true;
            Attack();
        }
    }

    private void Attack()
    {
        if(attack)
        {
            anim.SetTrigger("Attack");
            attack = false;
        }
    }

    private void Jump()
    {
        var ve = myBody.velocity;
        ve.y = 0;
        myBody.velocity = ve;

        myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        jumpCounter--;
    }

    private bool canJump(int Counter)
    {
        if (Counter > 0)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            jumpCounter = 2;
            anim.SetBool("IsInAir", false);
        }       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsInAir", true);
    }
}
