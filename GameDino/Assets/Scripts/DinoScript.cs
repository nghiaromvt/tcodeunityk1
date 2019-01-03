using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour {
    private Rigidbody2D myBody;
    private bool grounded=true;
    [SerializeField]
    private float jumpForce = 300f;
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded();
        }
	}

    private void isGrounded()
    {
        if(grounded)
        {
            Jump();
            grounded = false;
        }
    }

    private void Jump()
    {
        myBody.AddForce(new Vector2(0,jumpForce),ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
