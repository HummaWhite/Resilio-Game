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
    
    public GameObject ball;

    public Vector3 GetBallPickupPosition()
    {
        return gameObject.transform.position + new Vector3(0, 1, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] prefabs = { YellowBallPrefab, WhiteBallPrefab, BlueBallPrefab };
        ball = Instantiate(prefabs[Convert.ToInt32(BallType)], GetBallPickupPosition(), Quaternion.identity);
        ball.GetComponent<Ball>().pickupSpot = gameObject;
        ball.GetComponent<Ball>().ReturnToSpot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
