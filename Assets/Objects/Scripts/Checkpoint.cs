using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Global global;

    void Start()
    {
        global = FindObjectOfType<Global>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            global.checkpoint = this;
        }
    }
}
