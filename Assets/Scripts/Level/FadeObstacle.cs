using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeObstacle : MonoBehaviour {

    [SerializeField]
    private int buttonNumber = 0;

    [SerializeField]
    private float fadeSpeed = 1;

    [SerializeField]
    private Color fadeInColor = Color.white;

    [SerializeField]
    private Color fadeOutColor = Color.white;

    [SerializeField]
    private bool disableColliders = true;

    private float fadeCurrentValue = 1;
    private float fadeTargetValue = 1;

    private SpriteRenderer spriteRenderer;
    private Collider2D[] allColliders;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        allColliders = GetComponentsInChildren<Collider2D>();
        Trigger.AddToTriggerDown(buttonNumber, new UnityAction(FadeOut));
        Trigger.AddToTriggerUp(buttonNumber, new UnityAction(FadeIn));
    }

    private void Update() {
        fadeCurrentValue = Mathf.MoveTowards(fadeCurrentValue, fadeTargetValue, fadeSpeed * Time.deltaTime);
        Color c = Color.Lerp(fadeOutColor, fadeInColor, fadeCurrentValue);
        spriteRenderer.color = c;
        if (disableColliders) {
            foreach (Collider2D collider2d in allColliders) {
                if (c.a <= 0 && collider2d.enabled)
                    collider2d.enabled = false;
                else if (c.a >= 1 && !collider2d.enabled)
                    collider2d.enabled = true;
            }
        }
    }

    public void FadeOut() {
        fadeTargetValue = 0;
    }

    public void FadeIn() {
        fadeTargetValue = 1;
    }

}