using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1Script : MonoBehaviour {
    public Rigidbody2D sprite1, sprite2, sprite3, sprite4;

	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            sprite1.AddForce(Vector2.up * 500);
        }
        sprite2.velocity = new Vector2(5, 0);
        sprite3.AddForce(Vector2.left * 5,ForceMode2D.Force);
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            sprite4.AddForce(Vector2.left * 15, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sprite4.AddForce(Vector2.right * 15, ForceMode2D.Force);
        }

    }
}
