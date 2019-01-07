using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterScript : MonoBehaviour {
    private Rigidbody2D myBody;
    private Animator anim;
    public float speed;
    public float jumpForce;
    private bool grounded;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Movement();
	}

    private void Movement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        if(xAxis<0)
        {
            myBody.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
            anim.SetBool("IsWalking", true);
        }
        else if(xAxis>0)
        {
            myBody.AddForce(new Vector2(speed, 0),ForceMode2D.Force) ;
            anim.SetBool("IsWalking", true);
        }
        else if(xAxis==0)
        {
            anim.SetBool("IsWalking", false);
        }
        
        if(Input.GetKey(KeyCode.Space)&&grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            anim.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            anim.SetBool("IsJumping", false);
        }
    }
}
