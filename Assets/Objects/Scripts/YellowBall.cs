using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class YellowBall : Ball
{
    public override void LastBounceBehavior(Collision collision)
    {
        var contact = collision.contacts[0];
        var normal = contact.normal;
        Physics.gravity = -normal * 9.8f;
        var xrOrigin = FindObjectOfType<XROrigin>();

        var vector = Vector3.Normalize(xrOrigin.transform.position - contact.point);
        var forward = Vector3.Cross(normal, vector);

        //xrOrigin.MoveCameraToWorldLocation(contact.point + normal * 1.36144f);
        xrOrigin.transform.position = contact.point;

        xrOrigin.MatchOriginUpCameraForward(normal, forward);
        xrOrigin.MatchOriginUpOriginForward(normal, forward);
    }
}
