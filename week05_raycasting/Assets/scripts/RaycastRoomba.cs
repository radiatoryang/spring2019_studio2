using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on a flat Cylinder, as if it's a Roomba
// intent: the Roomba will move around, and turn if it hits a wall
public class RaycastRoomba : MonoBehaviour
{
    void Update()
    {
        // Roomba should always move forward, 2 meters per second
        transform.Translate(0f, 0f, 2f * Time.deltaTime );
        
        // STEP 1: make a Ray shooting out the front of the Roomba
        Ray myRay = new Ray( transform.position, transform.forward );

        // STEP 2: define the max raycast distance
        float maxRayDist = 2f;

        // STEP 3: debug and draw the ray
        Debug.DrawRay( myRay.origin, myRay.direction * maxRayDist, Color.cyan );

        // STEP 4: finally actually shoot the raycast
        if ( Physics.Raycast( myRay, maxRayDist ) ) {
            // if the raycast hits something, that means there's a wall in front

            // so, randomly turn left or turn right
            int randomNumber = Random.Range(0, 100);
            if ( randomNumber >= 50 ) { // 50% chance of turning left
                transform.Rotate(0f, -90f, 0f);
            } else { // 50% chance of turning right
                transform.Rotate(0f, 90f, 0f);
            }
        }
    }
}
