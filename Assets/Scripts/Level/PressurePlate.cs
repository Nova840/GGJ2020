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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onDown.Invoke();
            AudioSource.PlayClipAtPoint(pressedSound, Vector3.zero);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onUp.Invoke();
            AudioSource.PlayClipAtPoint(releasedSound, Vector3.zero);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider"))
            onHold.Invoke();
    }

}