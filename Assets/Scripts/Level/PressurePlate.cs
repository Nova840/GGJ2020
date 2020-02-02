using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour {

    [SerializeField]
    private UnityEvent onDown = null;

    [SerializeField]
    private UnityEvent onUp = null;

    [SerializeField]
    private UnityEvent onHold = null;

    [SerializeField]
    private AudioClip pressedSound = null;

    [SerializeField]
    private AudioClip releasedSound = null;

    [SerializeField, Range(0, 1)]
    private float volume = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onDown.Invoke();
            Sound.PlaySound(pressedSound, volume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onUp.Invoke();
            Sound.PlaySound(releasedSound, volume);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider"))
            onHold.Invoke();
    }

}