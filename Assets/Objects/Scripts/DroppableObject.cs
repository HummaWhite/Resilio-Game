using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroppableObject : MonoBehaviour
{

    public Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravityDir = Physics.gravity;
        if(gravityDir.z != 0){
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
