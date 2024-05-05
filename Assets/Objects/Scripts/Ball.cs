using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BallType { Yellow, White, Blue };
public enum BallState { InSpot, Picked, Thrown };

public class Ball : MonoBehaviour
{
    public int MaxBounceCount;
    public BallType Type;

    public int currentBounceCount = 0;
    public PickupSpot pickupSpot;
    public BallState state = BallState.InSpot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Magnitude(transform.position) > 100.0f)
        {
            ReturnToSpot();
        }
    }

    public void OnPickup()
    {
        state = BallState.Picked;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void OnThrow()
    {
        state = BallState.Thrown;
    }

    public void ReturnToSpot()
    {
        transform.SetPositionAndRotation(pickupSpot.GetBallPickupPosition(), Quaternion.identity);
        currentBounceCount = 0;
        state = BallState.InSpot;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    protected virtual void LastBounceBehavior(Collision collision)
    {
    }

    void OnLastBounce(Collision collision)
    {
        LastBounceBehavior(collision);
        ReturnToSpot();
    }

    void OnCollisionEnter(Collision collision)
    {
        var collider = collision.collider;

        if (collider.CompareTag("Boundary"))
        {
            ReturnToSpot();
        }
        else if (collider.CompareTag("PickupSpot"))
        {
            if (state == BallState.InSpot || state == BallState.Picked)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
        }
        else if (collider.CompareTag("Surface"))
        {
            if (state == BallState.Thrown)
            {
                currentBounceCount += 1;

                if (currentBounceCount == MaxBounceCount)
                {
                    OnLastBounce(collision);
                }
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        var collider = collision.collider;

        if (collider.CompareTag("Surface"))
        {
        }
    }
}
