using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Global : MonoBehaviour
{
    public Checkpoint checkpoint;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            ResetToLastCheckpoint();
        }
    }

    public void ResetToLastCheckpoint()
    {
        CharacterMove.Teleport(checkpoint.transform.position, checkpoint.transform.up);
    }
}
