using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {
    public Transform top;
    public Transform bottom;
    public Transform left;
    public Transform right;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        top.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        bottom.Translate(new Vector3(0, 2, 0) * Time.deltaTime);
        left.Translate(new Vector3(0.5f, 0, 0) * Time.deltaTime);
        right.Translate(new Vector3(-0.5f, 0, 0) * Time.deltaTime);
    }
}
