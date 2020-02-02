using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolumeToPlayerProximity : MonoBehaviour {

    private AudioSource audioSource;

    [SerializeField]
    private float minDistance = 1;

    [SerializeField]
    private float maxDistance = 5;

    [SerializeField]
    private SpriteRenderer multiplyByAlpha = null;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        float leftPlayerDistance = Mathf.Abs(Players.LeftPlayer.transform.position.x - transform.position.x);
        float rightPlayerDistance = Mathf.Abs(Players.RightPlayer.transform.position.x - transform.position.x);
        float distanceToClosestPlayer = leftPlayerDistance <= rightPlayerDistance ? leftPlayerDistance : rightPlayerDistance;
        float percentVolume = 1 - Mathf.InverseLerp(minDistance, maxDistance, distanceToClosestPlayer);
        if (multiplyByAlpha)
            percentVolume = percentVolume * multiplyByAlpha.color.a;
        audioSource.volume = percentVolume;
    }

}