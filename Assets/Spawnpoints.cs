using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoints : MonoBehaviour {

    [SerializeField]
    private Transform leftSpawnpoint = null;
    public static Transform LeftSpawnpoint { get { return instance.leftSpawnpoint; } }

    [SerializeField]
    private Transform rightSpawnpoint = null;
    public static Transform RightSpawnpoint { get { return instance.rightSpawnpoint; } }

    private static Spawnpoints instance;

    private void Awake() {
        instance = this;
    }

}