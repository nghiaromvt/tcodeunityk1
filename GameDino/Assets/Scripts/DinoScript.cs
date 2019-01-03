using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoScript : MonoBehaviour {
    public float JumpForce=300f;
    private Rigidbody2D myBody;
    public Text gameOver; 
	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            myBody.AddForce(new Vector2(0,JumpForce),ForceMode2D.Force);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Tree"))
        {
            Time.timeScale = 0;
            gameOver.gameObject.SetActive(true);
        }
    }
    public void Replay()
    {
        GameObject[] trees;
        trees=GameObject.FindGameObjectsWithTag("Tree");
        foreach (GameObject tree in trees)
        {
            Destroy(tree.gameObject);
        }
        Time.timeScale = 1;
        gameOver.gameObject.SetActive(false);
    }
}

