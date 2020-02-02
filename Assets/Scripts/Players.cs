using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour {

    [SerializeField]
    private bool isLeftPlayer = true;

    public static GameObject LeftPlayer { get; private set; }
    public static GameObject RightPlayer { get; private set; }

    private void Awake() {
        if (isLeftPlayer)
            LeftPlayer = gameObject;
        else
            RightPlayer = gameObject;
    }

}