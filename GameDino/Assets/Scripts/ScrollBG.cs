using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour {
    [SerializeField]
    private float Speed = 0.2f;
    private MeshRenderer render;
    private Vector2 offsetDefault;
	// Use this for initialization
	void Start () {
        render = GetComponent<MeshRenderer>();
        offsetDefault = render.sharedMaterial.GetTextureOffset("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
            float x = Mathf.Repeat(Time.time * Speed/transform.localScale.x, 1);
            Vector2 newOffset = new Vector2(x, offsetDefault.y);
            render.sharedMaterial.SetTextureOffset("_MainTex", newOffset);
    }
}
