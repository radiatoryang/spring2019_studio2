using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // you need this to talk to Text UI

// USAGE: put this on a Text object
// INTENT: a simple text game where we hold down SPACE for 10 seconds
public class SimpleTextGame : MonoBehaviour
{
    public Text myText; // assign in Inspector!
    float myScore = 0f; // store how long I've pressed SPACE

    // Update is called once per frame
    void Update()
    {
        // if player holds down SPACE, then do this:
        if ( Input.GetKey( KeyCode.Space ) ) {
            // add time to myScore
            myScore += Time.deltaTime;

            // Time.deltaTime is:
            // "delta" = difference
            // deltaTime = how long the frame was, in seconds
            // 60 FPS means dT = 1/60

            // concatenation = put strings together
            myText.text = "MY SCORE: " + myScore.ToString();
        }
    }
}
