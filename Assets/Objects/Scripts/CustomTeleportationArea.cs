using System;
using Unity.Collections;
using Unity.Mathematics;
using Unity.XR.CoreUtils;
using Unity.XR.CoreUtils.Bindings;
using Unity.XR.CoreUtils.Bindings.Variables;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Curves;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
/// An area is a teleportation destination which teleports the user to their pointed
/// location on a surface.
/// </summary>
/// <seealso cref="TeleportationAnchor"/>
// [AddComponentMenu("XR/Teleportation Area", 11)]
// [HelpURL(XRHelpURLConstants.k_TeleportationArea)]
// public class CustomTeleportationArea : BaseTeleportationInteractable
// {
//     /// <inheritdoc />
//     protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref teleportRequest)
//     {
//         if (raycastHit.collider == null)
//             return false;

//         teleportRequest.destinationPosition = raycastHit.point;
//         teleportRequest.destinationRotation = transform.rotation;
//         return true;
//     }
// }