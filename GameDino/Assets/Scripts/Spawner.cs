using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject tree;
    public GameObject tree2;
    public GameObject tree3;
	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Spawn()
    {
            yield return new WaitForSeconds(Random.Range(1, 4));
            int chance = Random.Range(1, 4);
            if (chance == 1)
            {
                Instantiate(tree, transform.position, Quaternion.identity);
            }
            else if (chance == 2)
            {
                Instantiate(tree2, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(tree3, transform.position, Quaternion.identity);
            }
        StartCoroutine(Spawn());
    }
}
