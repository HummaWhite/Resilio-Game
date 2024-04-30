using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class YellowBall : Ball
{
    protected override void LastBounceBehavior(Collision collision)
    {
        var contact = collision.contacts[0];
        var position = contact.point;
        position = collision.gameObject.transform.position;
        CharacterMove.Teleport(position, contact.normal);
    }
}
