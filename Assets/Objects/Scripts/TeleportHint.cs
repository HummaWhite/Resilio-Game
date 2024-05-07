using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportHint : MonoBehaviour {
    public float Duration;
    public GameObject HintPointPrefab;
    public GameObject HintLinePrefab;

    GameObject hintPoint;
    GameObject hintLine;
    float timer = 0;

    float getHintAnimationScale(float alpha) {
        return (0.5f - Math.Abs(alpha - 0.5f)) * 2.0f;
    }

    Vector3 GetHintLinePosition() {
        return (transform.position + CharacterMove.xrOrigin.transform.position) * 0.5f;
    }

    Vector3 GetHintLineDirection() {
        return Vector3.Normalize(transform.position -  CharacterMove.xrOrigin.transform.position);
    }

    float GetHintLineScale() {
        return Vector3.Magnitude(transform.position -  CharacterMove.xrOrigin.transform.position);
    }

    void UpdateHintObejcts() {
        float scale = getHintAnimationScale(timer / Duration);
        hintPoint.transform.localScale = new Vector3(scale, scale, scale);

        hintLine.transform.position = GetHintLinePosition();
        hintLine.transform.up = GetHintLineDirection();

        var lineScale = new Vector3(hintLine.transform.localScale.x, GetHintLineScale(), hintLine.transform.localScale.z);
        hintLine.transform.localScale = lineScale;
    }

    void Start() {
        hintPoint = Instantiate(HintPointPrefab, transform.position, Quaternion.identity);
        hintLine = Instantiate(HintLinePrefab, GetHintLinePosition(), Quaternion.identity);
        UpdateHintObejcts();
    }

    void Update() {
        if (timer > Duration) {
            Destroy(hintPoint);
            Destroy(hintLine);
            Destroy(gameObject);
        }
        UpdateHintObejcts();
        timer += Time.deltaTime;
    }
}
