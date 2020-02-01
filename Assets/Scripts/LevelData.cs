using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour {

    [SerializeField]
    private Transform leftSpawnpoint = null;
    public static Transform LeftSpawnpoint { get { return instance.leftSpawnpoint; } }

    [SerializeField]
    private Transform rightSpawnpoint = null;
    public static Transform RightSpawnpoint { get { return instance.rightSpawnpoint; } }

    [SerializeField]
    private float levelSizeForCamera = 10;
    public static float LevelSizeForCamera { get { return instance.levelSizeForCamera; } }

    private static LevelData instance;

    private void Awake() {
        instance = this;
    }

}