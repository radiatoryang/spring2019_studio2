using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// USAGE: put this script on a Cube
// FUNCTION: tween the Cube to a new position using coroutines
public class TweenCoroutine : MonoBehaviour
{

    public AnimationCurve myTweenCurve;

    void Start()
    {
        // to call a Coroutine, you MUST use "StartCoroutine"
        StartCoroutine( MyFirstCoroutine() );
    }

    // a coroutine is a function that can:
    // - last more than 1 frame
    // - we can control how fast it runs
    IEnumerator MyFirstCoroutine () {
        Debug.Log("started coroutine!...");

        yield return 0; // pause for 1 frame
        // ... then the code continues...

        Debug.Log("ok, waited 1 frame, now continuing...");

        yield return 0; // how to wait for 2 frames...
        yield return 0;

        Debug.Log("ok, waited for 2 more frames, now continuing...");

        yield return new WaitForSeconds( 1f ); // wait for 1 second

        Debug.Log("ok, waited for 1 second, now continuing...");

        // let's use a coroutine to tween the cube to a new position
        float timer = 0f;
        Vector3 startPos = transform.position;
        Vector3 endPos = new Vector3(0f, 0f, 5f);
        while ( timer < 1f ) {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp( startPos, endPos, myTweenCurve.Evaluate(timer) );
            yield return 0;
        }

    }

    public Vector3 targetPos;

    void Update()
    {
        // you don't need coroutines to smooth your movements

        // for example, to make the cube SMOOTHLY go to its target...
        transform.position += (targetPos - transform.position) * 0.1f;
    }


}
