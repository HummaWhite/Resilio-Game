using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PickupSpot : MonoBehaviour
{
    public BallType BallType;
    public GameObject YellowBallPrefab;
    public GameObject WhiteBallPrefab;
    public GameObject BlueBallPrefab;
    
    public Ball ball;

    public float ballSize = 1.0f;

    public Vector3 GetBallPickupPosition()
    {
        return transform.position + transform.up * 0.5f * ballSize * 0.05f;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] prefabs = { YellowBallPrefab, WhiteBallPrefab, BlueBallPrefab };
        ball = Instantiate(prefabs[Convert.ToInt32(BallType)], GetBallPickupPosition(), Quaternion.identity).GetComponent<Ball>();
        ballSize *= 20.0f;
        ball.transform.localScale = new Vector3(ballSize,ballSize,ballSize);
        ball.pickupSpot = this;
        ball.ReturnToSpot();

        GetComponent<MeshRenderer>().material.color = ball.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            ball.ReturnToSpot();
        }
    }
}
