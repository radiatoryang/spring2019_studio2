using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this script on an empty game object called "Forest Manager"
// PURPOSE: this will spawn many tree clones in a flat area
public class ForestGen : MonoBehaviour
{
    // STEP 1 for instantiating things: declare a prefab
    public GameObject myTreePrefab; // don't forget: assign in Inspector!

    void Start()
    {
        // STEP 2 for instantiating things: call the Instantiate function

        // a "while loop" will repeat code until its condition is no longer true
        int treeCounter = 0; // count how many trees we made
        while ( treeCounter < 100 ) {
            // step 3a: generate a random position
            Vector3 randomPos = new Vector3(Random.Range(-10f, 10f),0f,Random.Range(-10f, 10f) );
            // step 3b: spawn a tree at the random position
            GameObject myClone = Instantiate( 
                myTreePrefab, 
                randomPos, 
                Quaternion.Euler(0f, Random.Range(0, 360) ,0f) 
            );
            // let's do more with the tree...
            myClone.transform.localScale *= Random.Range(0.75f, 1.3f); // random 75-130% size
            myClone.GetComponentsInChildren<Renderer>()[1].material.color = Random.ColorHSV(); // random color
                // ColorHSV = Hue, Saturation, Value, a better way to generate a color than RGB
            treeCounter++; // increment tree counter ("++" means "add 1 to current value")
        }

    }

}
