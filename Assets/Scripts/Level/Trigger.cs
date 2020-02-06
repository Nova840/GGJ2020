using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour {

    [SerializeField]
    private int buttonNumber = 0;

    private static List<Trigger> allTriggers = new List<Trigger>();

    [SerializeField]
    private UnityEvent onDown = null;

    [SerializeField]
    private UnityEvent onUp = null;

    [SerializeField]
    private AudioClip pressedSound = null;

    [SerializeField]
    private AudioClip releasedSound = null;

    [SerializeField, Range(0, 1)]
    private float volume = 1;

    private void Awake() {
        allTriggers.Add(this);
    }

    private void OnDestroy() {
        allTriggers.Remove(this);
    }

    public static void AddToTriggerDown(int buttonNumber, UnityAction action) {
        List<Trigger> triggers = allTriggers.FindAll(t => t.buttonNumber == buttonNumber);
        foreach (Trigger trigger in triggers)
            trigger.onDown.AddListener(action);
    }

    public static void AddToTriggerUp(int buttonNumber, UnityAction action) {
        List<Trigger> triggers = allTriggers.FindAll(t => t.buttonNumber == buttonNumber);
        foreach (Trigger trigger in triggers)
            trigger.onUp.AddListener(action);
    }

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

}