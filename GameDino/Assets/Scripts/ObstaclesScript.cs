using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 5f;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime,
            transform.position.y);       
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameControllerScript.instance.DinoHit(gameObject.name);
        }
        if(collision.CompareTag("KillPoint"))
        {
            GameControllerScript.instance.CountObstacle();
            Destroy(gameObject);
        }
    }

}
