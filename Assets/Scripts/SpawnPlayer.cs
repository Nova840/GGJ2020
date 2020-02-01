using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour {

    [SerializeField]
    private bool spawnLeft = true;

    private void Start() {
        float zPos = transform.position.z;
        Vector3 spawnPosition = spawnLeft ? LevelData.LeftSpawnpoint.position : LevelData.RightSpawnpoint.position;
        spawnPosition.z = zPos;
        transform.position = spawnPosition;
    }

}