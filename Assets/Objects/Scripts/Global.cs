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
        if (Input.GetButtonDown(ValueShortcut.InputName_Jump))
        {
            ResetToLastCheckpoint();
        }

        /*
        for (KeyCode i = KeyCode.Joystick1Button0; i <= KeyCode.Joystick1Button19; i++) {
            if (Input.GetKeyDown(i)) {
                Debug.Log(i);
            }
        }
        */
    }

    public void ResetToLastCheckpoint()
    {
        CharacterMove.Teleport(checkpoint.transform.position, checkpoint.transform.up);
    }
}
