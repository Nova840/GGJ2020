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

    [SerializeField]
    private float maxDistance = 10;

    private void Update() {
        Transform leftmostPlayer = leftPlayer.position.x <= rightPlayer.position.x ? leftPlayer : rightPlayer;
        Transform rightmostPlayer = leftPlayer.position.x <= rightPlayer.position.x ? rightPlayer : leftPlayer;

        float smallCameraWidth = GetWidth(leftCamera);

        SetXPosition(leftCamera.transform, Mathf.Max(leftmostPlayer.position.x, -maxDistance));
        SetXPosition(rightCamera.transform, Mathf.Min(rightmostPlayer.position.x, maxDistance));
        SetXPosition(middleCamera.transform, Mathf.Clamp((rightmostPlayer.position.x + leftmostPlayer.position.x) / 2, -maxDistance + smallCameraWidth / 2, maxDistance - smallCameraWidth / 2));

        SetMiddleCameraMode(Mathf.Abs(rightmostPlayer.position.x - leftmostPlayer.position.x) < smallCameraWidth);//x distance between players is less than the smaller camera's width
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