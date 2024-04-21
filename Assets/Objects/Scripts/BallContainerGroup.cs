using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallContainerGroup : MonoBehaviour
{
    public List<BallContainer> containers;

    // Start is called before the first frame update
    void Start()
    {
        containers = new List<BallContainer>();
        containers = GetComponentsInChildren<BallContainer>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
