using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoScript : MonoBehaviour {
    private Rigidbody2D myBody;
    private bool grounded;
    [SerializeField]
    private float jumpForce = 300f;
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    private void Jump()
    {
        if(grounded)
        {
            myBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
            grounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
