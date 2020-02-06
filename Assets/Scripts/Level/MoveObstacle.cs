using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveObstacle : MonoBehaviour {

    private bool lifted = false;

    private Vector3 originalPosition;

    [SerializeField]
    private int objectNumber = 0;

    [SerializeField]
    private float liftedOffset = 1;

    [SerializeField]
    private float liftSpeed = 5;

    [SerializeField]
    private AudioClip elevatorUp = null;

    [SerializeField]
    private AudioClip elevatorDown = null;

    [SerializeField, Range(0, 1)]
    private float volume = 1;

    private void Awake() {
        originalPosition = transform.position;
        Trigger.AddToTriggerDown(objectNumber, new UnityAction(SetUp));
        Trigger.AddToTriggerUp(objectNumber, new UnityAction(SetDown));
    }

    private void Update() {
        Vector3 offset = lifted ? transform.up * liftedOffset : Vector3.zero;
        transform.position = Vector3.MoveTowards(transform.position, originalPosition + offset, liftSpeed * Time.deltaTime);
    }

    public void SetUp() {
        lifted = true;
        Sound.PlaySound(elevatorUp, volume);
    }

    public void SetDown() {
        lifted = false;
        Sound.PlaySound(elevatorDown, volume);
    }

}