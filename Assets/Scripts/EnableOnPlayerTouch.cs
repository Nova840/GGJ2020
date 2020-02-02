using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnPlayerTouch : MonoBehaviour {

    [SerializeField]
    private Behaviour toEnable = null;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("MainPlayerCollider")) {
            toEnable.enabled = true;
        }
    }

}