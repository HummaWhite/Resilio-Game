using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Global global;
    public Vector3 gravity;
    void Start()
    {
        global = FindObjectOfType<Global>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(ValueShortcut.Tag_Player))
        {
            global.checkpoint = this;
            gravity = Physics.gravity;
        }
    }
}
