using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLoaded : MonoBehaviour {

    public static bool HasLoaded { get; private set; } = false;

    private void Awake() {
        HasLoaded = true;
    }

}