using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class YellowBall : Ball
{
    [SerializeField] float PlayerChooseTimeSlot = 3.0f;
    [SerializeField] GameObject TeleportHintObejct;

    GameObject _poshint;
    float _timer = 0;
    bool _startChooseTime = false;

    void Update(){
        if(_startChooseTime){
            if(_timer > PlayerChooseTimeSlot) {
                _startChooseTime = false;
                _timer = 0;
            }

            if(Input.GetKeyDown(KeyCode.Joystick1Button15)) {
                CharacterMove.Teleport(_poshint.transform.position + _poshint.transform.up.normalized * 0.3f, _poshint.transform.up);
            }

            _timer += Time.deltaTime;
        }
    }

    protected override void LastBounceBehavior(Collision collision)
    {
        var contact = collision.contacts[0];
        var position = contact.point;
        _startChooseTime = true;

        _poshint = Instantiate(TeleportHintObejct, position, Quaternion.identity);
        _poshint.transform.up = contact.normal;
    }
}
