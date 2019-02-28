using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this script on a Cube
// intent / function: shoot a raycast below the Cube, to see if it is standing on a platform
public class RaycastGrounded : MonoBehaviour
{
    public bool isGrounded;

    void Update()
    {
        // STEP 1 FOR RAYCASTING: make / declare a "Ray" object
        Ray ray = new Ray(transform.position, Vector3.down );

        // STEP 2: specify maximum raycast distance
        float raycastDist = 0.6f; // half the character's height + a bit more?

        // STEP 3: (optional, but recommended) DEBUG DRAW the RAYCAST
        Debug.DrawRay(ray.origin, ray.direction * raycastDist, Color.yellow);

        // STEP 4: actually do the raycast??
        if ( Physics.Raycast( ray, raycastDist ) ) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

    }
}
