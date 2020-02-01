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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onDown.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            onUp.Invoke();
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider"))
            onHold.Invoke();
    }

}