using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContainer : MonoBehaviour
{
    public GameObject objectToUnlock;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

        if (collider.CompareTag("Ball"))
        {
            var ball = collider.GetComponent<Ball>();

            if (ball != null && ball.Type == BallType.Blue)
            {
                //objectToUnlock.GetComponent<Unlockable>().Unlock();
                Debug.Log("Hellow");
            }
        }
    }
}
