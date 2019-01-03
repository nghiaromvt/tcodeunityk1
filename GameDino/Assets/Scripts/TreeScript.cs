using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {
    private Rigidbody2D myBody;
    public float Speed=5f;
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        myBody.velocity = new Vector2(-Speed,0);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
