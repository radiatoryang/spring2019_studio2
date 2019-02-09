using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this on a Cube
// PURPOSE: let player control Cube with WASD
public class CubeMove : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // hold down W to make Cube move forward
        if ( Input.GetKey(KeyCode.W) ) {
            transform.Translate(0f, 0f, moveSpeed);
        }

        // hold down S to make Cube move backward
        if ( Input.GetKey(KeyCode.S) ) {
            transform.Translate(0f, 0f, -moveSpeed);
        }

        // hold down D to make Cube move right
        if ( Input.GetKey(KeyCode.D) ) {
            transform.Translate(moveSpeed, 0f, 0f);
        }

        // hold down A to make Cube move left
        if ( Input.GetKey(KeyCode.A) ) {
            transform.Translate(-moveSpeed, 0f, 0f);
        }

    }
}
