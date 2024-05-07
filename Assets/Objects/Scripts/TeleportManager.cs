using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class TeleportManager : MonoBehaviour
{
    public XRInteractorLineVisual teleportPos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var rayInteractor = FindObjectOfType<XRRayInteractor>();

        if (rayInteractor == null) {
            teleportPos = null;
            return;
        }

        teleportPos = rayInteractor.GetComponent<XRInteractorLineVisual>();
        var point = teleportPos.reticle;

        if (Input.GetKeyDown(KeyCode.Joystick1Button15)) {
            CharacterMove.Teleport(point.transform.position + point.transform.up.normalized * 0.3f, point.transform.up);
        }
    }
}
