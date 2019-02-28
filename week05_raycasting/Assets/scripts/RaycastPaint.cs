using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on your Main Camera
// intent: move the sphere based on our mouse cursor
public class RaycastPaint : MonoBehaviour
{
    public Transform mySphere; // assign in Inspector

    // Update is called once per frame
    void Update()
    {
        // STEP 1: declare some kind of Ray object; project a ray based on mouse
        Ray myRay = Camera.main.ScreenPointToRay( Input.mousePosition );
        
        // STEP 2: declare a maximum raycast distance
        float maxRayDist = 2000f; // just a big number, because infinity scares me

        // STEP 3: (optional) visualize our raycast
        Debug.DrawRay( myRay.origin, myRay.direction * maxRayDist, Color.yellow );

        // STEP 3.5: declare a RaycastHit object to remember where it hit
        RaycastHit myRayHit = new RaycastHit(); // blank var, with no data yet

        // STEP 4: let's shoot our raycast
        if ( Physics.Raycast( myRay, out myRayHit, maxRayDist ) ) {
            // move sphere to where the raycast hit
            mySphere.position = myRayHit.point; // "point" = world pos that it hit

            // instantiate / "clone" the sphere at this point
            Instantiate( mySphere.gameObject );
        }
    }
}
