using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupSpot : MonoBehaviour
{
    public BallType BallType;
    public GameObject YellowBallPrefab;
    public GameObject WhiteBallPrefab;
    public GameObject BlueBallPrefab;
    
    public Ball ball;

    public Vector3 GetBallPickupPosition()
    {
        return transform.position + transform.up * 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] prefabs = { YellowBallPrefab, WhiteBallPrefab, BlueBallPrefab };
        ball = Instantiate(prefabs[Convert.ToInt32(BallType)], GetBallPickupPosition(), Quaternion.identity).GetComponent<Ball>();
        ball.pickupSpot = this;
        ball.ReturnToSpot();

        GetComponent<MeshRenderer>().material.color = ball.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Jump"))
        {
            ball.ReturnToSpot();
        }
    }
}
