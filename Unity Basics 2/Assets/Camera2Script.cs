using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2Script : MonoBehaviour
{
    public Rigidbody object1, object2, object3, object4;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            object1.AddForce(Vector2.up * 500);
        }
        object2.velocity = new Vector2(5, 0);
        object3.AddForce(Vector2.left * 5, ForceMode.Force);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            object4.AddForce(Vector2.left * 15, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            object4.AddForce(Vector2.right * 15, ForceMode.Force);
        }
    }
}
