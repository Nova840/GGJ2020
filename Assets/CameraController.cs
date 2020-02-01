using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Transform leftPlayer = null;

    [SerializeField]
    private Transform rightPlayer = null;

    [SerializeField]
    private Camera leftCamera = null;

    [SerializeField]
    private Camera rightCamera = null;

    [SerializeField]
    private Camera middleCamera = null;

    [SerializeField]
    private Image dividerImage = null;

    private void Update() {
        SetXPosition(leftCamera.transform, leftPlayer.position.x);
        SetXPosition(rightCamera.transform, rightPlayer.position.x);
        SetXPosition(middleCamera.transform, (rightPlayer.position.x + leftPlayer.position.x) / 2);

        SetMiddleCameraMode(Mathf.Abs(rightPlayer.position.x - leftPlayer.position.x) < GetWidth(leftCamera));//x distance between players is less than the smaller camera's width
    }

    private void SetXPosition(Transform t, float x) {
        t.position = new Vector3(x, t.position.y, t.position.z);
    }

    private void SetMiddleCameraMode(bool middleCamEnabled) {
        if (middleCamera.enabled != middleCamEnabled) {//only change it if it needs to be changed
            middleCamera.enabled = middleCamEnabled;
            leftCamera.enabled = !middleCamEnabled;
            rightCamera.enabled = !middleCamEnabled;
            dividerImage.enabled = !middleCamEnabled;
        }
    }

    private float GetWidth(Camera cam) {
        float height = 2 * cam.orthographicSize;
        float width = height * cam.aspect;
        return width;
    }

}