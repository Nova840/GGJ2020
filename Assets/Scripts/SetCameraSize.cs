using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraSize : MonoBehaviour {

    private void Start() {
        GetComponent<Camera>().orthographicSize = LevelData.CameraSize;
    }

}